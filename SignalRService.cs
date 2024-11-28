using BackEleccionsM.Dto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace FrontEleccM
{
    public class SignalRService : IAsyncDisposable
    {
        private readonly HubConnection _hubConnection;

        // Evento para notificar cuando se actualiza un "PartitPolitic"
        public event Action<PartitPoliticDto>? PartitUpdated;

        public SignalRService(NavigationManager navigationManager)
        {
            // Configuración de la conexión al Hub de SignalR
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/datahub"))  // URL del Hub en el servidor
                .WithAutomaticReconnect()  // Permite que SignalR intente reconectarse automáticamente si se pierde la conexión
                .Build();

            // Configuración para escuchar el evento "UpdatePartits" desde el servidor
            _hubConnection.On<PartitPoliticDto>("UpdatePartits", (partitUpdate) =>
            {
                // Cuando se recibe el evento "UpdatePartits", invoca el evento local "PartitUpdated"
                PartitUpdated?.Invoke(partitUpdate);
            });
        }

        // Método para iniciar la conexión con el Hub
        public async Task StartAsync()
        {
            await _hubConnection.StartAsync();
        }

        // Método para detener y limpiar la conexión cuando ya no se necesite
        public async ValueTask DisposeAsync()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.StopAsync();  // Detener la conexión con el Hub
                await _hubConnection.DisposeAsync();  // Limpiar recursos asociados con la conexión
            }
        }
    }
}
