# Aplicación del Challenge MeetupSantander 

En este challenge se creó una base de datos en Microsoft SQL Server, una API en .Net Core 3.1 en C# y una aplicación para el usuario final en Angular 9.
La aplicación final tanto como la API se encuentran publicadas en un servidor de Azure para su facil acceso y visualización:
- Aplicación final: https://meetupsantander.azurewebsites.net
- API: https://meetupsantanderapi20200429144432.azurewebsites.net
- Base de datos: meetupsantanderapi20200429144432dbserver.database.windows.net

Nota: La cantidad de cajas de cervezas como asi tambien la temperatura de la fecha de la meetup funcionan para fechas del dia actual hasta 7 dias para adelante, ya que el forecast de la API del clima que se utiliza devuelve esa información, y no funciona para meetups de fechas pasadas o que superen el forecast. A su vez tambien la API del clima contiene un límite de llamadas por día, ya que es una subscripción gratuita.

Detalles:
- Aplicación final: Aplicación hecha en Angular 9 con la integración de los módulos de AuthGuard para la autorización de acceso a la pantalla y control de usuario loggeado. Tambien se utilizó in JWT interceptor con HttpInterceptor para agregar a todo request a la API el Bearer con el token del usuario loggeado automáticamente. HttpClient para los requests a la API. FormsModule para la validación y manipulación de información en los formularios.
- API: Hecha con .Net Core 3.1 la cual esta separada en capas de DTO, dominio o servicio, datos y test. Utiliza EntityFramework.Core que conecta al SQL Server, AutoMapper para el mapeo de los objetos por capa, Swashbuckle para Swagger, AspNetCore.Authentication para el control del JWT, DI (dependency injection) y control de Excepciones.

# MeetupSantander.API.Documentacion

Contiene:
- El DER de la base de datos
- Archivo JSON de Postman para importar los requests a la API desde dicho programa.
- Imágenes de la aplicación de usuario final con sus correspondientes pantallas.

# MeetupSantander.API

Proyecto principal de la API, el cual recibe todas las llamadas desde un cliente.

## String de conexión hacia la base de datos Microsoft SQL Server

El string connection esta en el archivo:
- appsettings.json

## Development environment

Abrir la solucion entera ejecutando el archivo MeetupSantander.sln con Visual Studio. Desde allí se van a visualizar todas las capas del proyecto y su codigo fuente. Desde allí se puede ejecutar un servidor IIS express para correr la API.

## Build

Desde el Visual Studio, en el proyecto MeetupSantander.API, se puede hacer el `Publish` hacia un servidor especifico.

## URL de conexión hacia la API del clima

La URL para el acceso a la API del clima y sus configuraciones del Key de usuario esta en el archivo:
- appsettings.json

# MeetupSantander.API.Contract

Proyecto el cual contiene los objetos DTO (Data Transfer Objects) de contrato que va a ser utilizado para la transferencia de información entre el frontend y el backend.

# MeetupSantander.API.Domain

Capa de dominio y servicios, la cual contiene las entidades dominio de la API y las implementaciones de los servicios que son requeridos desde MeetupSantander.API. A su vez también contienen las interfaces de contrato para la utilización de la capa MeetupSantander.API.Data.

# MeetupSantander.API.Data

Capa de datos que contiene la implementación de la conexión a la base de datos para la búsqueda de información y manipulación de datos.

# MeetupSantander.API.Test

Proyecto de test unitario el cual se hizo un ejemplo de la obtención de cajas de cerveza.

# MeetupSantander.API.Database

Carpeta la cual contiene el archivo .bak y el archivo .sql (scripts de la base de datos tanto de estructura como de datos) de Microsoft SQL Server para hacer el restore de la misma si se quiere por ese medio. Desde el Microsoft SQL Server Management Studio se puede hacer un restore llamando a dicho archivo .bak o bien la ejecución de todo el script en el archivo .sql.

# MeetupSantander.API.UI

Proyecto de la aplicación de User Interface hecho en Angular 9 para el usuario final. Desde este cliente es donde se hacen las llamadas a la API y comportamientos para el usuario final. Cuenta con sus correspondientes folders para separar los servicios, los modelos, environments que contienen información de la API y las pantallas.

## String de conexión hacia la API

La URL de la API se encuentra en los siguientes archivos:
- proxy.conf.json: Dicho archivo corresponde a la configuración para habilitar el AllowAnyOrigin del CORS y hacer las pruebas correspondientes.
- environment.prod.ts: Archivo del cual toma la URL para los requests en el ambiente de producción.
- environment.ts: Archivo del cual toma la URL para los requests en el ambiente de desarrollo.

## Development environment

Ejecutar `npm i` para instalar todas las dependencias.

Ejecutar `ng serve -o` para visualizar la aplicación desde el explorador de internet predeterminado.

## Build

Ejecutar `ng build --watch` para generar los archivos en /dist/<nombre del proyecto> y copiar los archivos a un sevidor.

# MeetupSantander.API.Android

Utilizando las librerías de Apache Cordova, hice un buid de una aplicación de Android. El archivo .apk existente en el raíz de dicho directorio puede ser instalado en algun dispositivo móvil con Android o algun emulador tambien. Aprovechando la existencia del proyecto en Angular, las librerías de Cordova se pueden utilizar para el deploy cross-platform. Si se desea instalar dicha apk se debe permitir las "fuentes desconocidas" en las configuraciones del dispositivo.

# Faltantes aplicables

A continuación se mencionan los items faltantes del ejercicio:
- Notificaciones: "Como usuario y como admin quiero poder recibir notificaciones para estar al tanto de las meetups". Las notificaciones pueden hacerse a traves de la plataforma de Google Firebase (https://firebase.google.com/products/cloud-messaging?hl=es). Tiene que haber un evento disparador de la misma y el cliente al estar subscripto a dicha notificación deberia recibirla.
- Invitaciones a una meetup por parte del administrador: simplemente agregando una nueva entidad para administrar las invitaciones o mismo modificar la ya existente de inscripciones para contemplar las invitaciones tambien, como asi con el checkin que ya existe.
- Cache: en proyectos anteriores he tenido la posibilidad de utilizar Redis para la cache. Cuando el cliente no tiene conectividad hacia la API, se pueden guardar en cache dicha información para cuando retorne la conexión (https://redis.io/).