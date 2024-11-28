namespace FrontEleccM.FrontServices
{
	using System;
using System.Collections.Generic;
using BackEleccionsM.Dto;

public class StateService
{
    // Estado compartido: Municipio seleccionado
    private MunicipiDto? _selectedMunicipi;
    public MunicipiDto? SelectedMunicipi
    {
        get => _selectedMunicipi;
        set
        {
            if (_selectedMunicipi != value)
            {
                _selectedMunicipi = value;
                NotifyStateChanged();
            }
        }
    }

    // Estado compartido: Lista de municipios
    private List<MunicipiDto> _municipis = new();
    public List<MunicipiDto> Municipis
    {
        get => _municipis;
        set
        {
            if (_municipis != value)
            {
                _municipis = value;
                NotifyStateChanged();
            }
        }
    }

    // Evento para notificar cambios
    public event Action? OnStateChanged;

    private void NotifyStateChanged() => OnStateChanged?.Invoke();
}

}
