# SUPUESTO PRACTICO SENIOR BACKEND DEVELOPER .NET
Este es un proyecto en .net framework 4.7.2, generado para una prueba de ingreso a una compañia de desarrollo de software el acceso a Basede datos es mediante LINQ. La base de datos es generada que sea montada en un servidor SQL SERVER, cuenta con estructura de tablas y procedimientos almacenados.

Los usuarios cargados por defecto son admon, usuario1 y usuario2. El primero cuenta con el rol administrador y los otros dos usuarios son rol usuario. Cada rol cuenta con permisos especificos,según el enunciado proporcionado.

Los datos de autenticación de los usuarios son los siguientes:

nombre de usuario: admon
contraseña: admin123

nombre de usuario: usuario1
contraseña: usuario1.

nombre de usuario: usuario2
contraseña: usuario2.2

El api cuenta con una seguridad en los endpoint cuenta con un filtro de sesión y otro por token. Por lo tanto,es necesario que para el consumo de cualquier método diferente a Login o closeSession se proporcione el sessionId y el token obtenido como resultado de la autenticación.

Los metodos presentes en el controllador de Administrador solo estan disponibles para el administrador y los que se encuentran en el usuario solo estan disponibles para el usuario.

La sessión cuenta con un tiempo de expiración de 15 minutos, y por lo tanto requiere que se realice nuevamente el proceso de autenticación.Por ultimo el api se encuentra docuementado con swagger.

A continuación un ejemplo delresultado al momento de autenticarse de forma exitosa.
```sh
{
  "sessionId": "cba41f2a-7f2b-46ab-b3df-cc9d6ebfd741",
  "user": {
    "usrID": 3,
    "usr_code": "03",
    "usr_userName": "usuario2",
    "usr_password": "t92/vEznbbKwzU5sYCPcJQ==",
    "usr_fullName": "Usuario DOS",
    "usr_documentType": "1",
    "usr_numberDocument": "1223456789",
    "usr_email": "usuario2@gmail.com",
    "usr_balance": 11000,
    "usr_role": "02",
    "usr_creationUser": null,
    "usr_creationDate": null,
    "usr_modificationUser": null,
    "usr_modificationDate": null,
    "usr_status": "V"
  },
  "token": "WL3FhuU2Y1Fv8N1l5+DlPQ0/NMEIG3Q6Xim/5+vgzX/gaHURHh2mLVhbuACkwQIzldkmtloGQMk2nX0yzB5C8Zu7QSXevy1Zv+3ycD1/xYPQ+s9Wsti77MDc9xVxB4GwL+1WlMnIXbFWBrY9KBIvhGudn0rFb1hJIdQzB9CLNqWfOAkjrldj3bKGqnXAKwbXBY7cLOkkQBcUizVN4vfRTorBiSbBqL3RND9cwhrAs2gUK+1+gVldhqisGNqfGROoxVohiFB+1VKsbtjtFdwmd7nlx59jd4EQKrRkzd/ZMPUSifcg03BqgtauSlks7Z7E4ox+DTKGLY2RHgK7MXczLOTbTkK8jUO/REa5T//MPRqc/vPt8/n9SaghuiWn5srUdfWj7XdY6vOCCnFSGZJYg8NvSBCOU1nxbqrsK8jxUd3DbeLO4ILMbDe58EUQMXd0x2O7xyM1gdYhckjF/4jxh7Rwkuwdpi7PfeWgmdrkN8TZOP1EqjXbJYCLiCPivyQ0VSE6aLAfoSeIxJWHrlqE7NXC7GUX0kZMn3zUp/ZDCpYsdwf6nCjUA3BC+H/Rnbrj1REcbymdId3BPq6RDt+QjD0Wx0kpnKfAo6deIwaLTa6ZpyNwz/T5wDqPmL48kKuM",
  "result": 0,
  "message": null
}
```

