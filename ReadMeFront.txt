Con el problema del css Boostrap o las clases personalizadas:

es muy relevante el orden en que se llama en index.html los stylesheets.
(en este caso como el proyecto tiene mucha base de boostrap mejor ponerlo debajo (asi el programa detecta que es la prioridad))

#Implementar SignalR-> Descargarmos como extension SignalR.Client en el proyecto de front "DiaElecciones tiempo real"
#PaySystem Stripe/PayPal "Metodo de pago"
#Azure / OAuth/ JWT Tokens "Control de accesos Usuario"

-potser un dto amb tot? municipis dins taules y partits, dins candidats, dins resultats y vots..? un dto igual al model?

TODO:::::::::::
1-El dia de les eleccions nomes es podra accedir a resultats per X persones que posaran resultats y a
dia eleccions per veure com van els resultats.

2-Y els dies abans nomes es podra accedir a configuració.

3-Esons empate regular-ho(ara esta sense alternativa dempat).

4-Tener en cuenta que solo se crean la lista de vots cuando se crea la tabla, osea si creo un nuevo partido
no se crea esa lista hbaria que crear la tabla otra vez xd Es que sino que.
((Control de proceso: 1Config(asegurarse que es correcto: y luego dia elecciones: resultats+eleccions))

5Mejorar la arquitectra del proyecto con un StateService y los ModelServices(frontServices) creados.

Testing MVP 

6-CSS project improve

7-Añadir una forma de añadir data en Configuracio de forma mas sencilla?

8-Poner la securekey del token en una variable de entorno para protegerla (nose como)
(en cas demergencia i s hagi de fer un canvi a ultima hora que es fa???)

A MILLORAR FUNCIONS:((optimització))
getVotsResultat()
createVotsList()
nose si esta be la func de actualitzar
butonclick()

