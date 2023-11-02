# Api_Libros

##Esta api es de libros y cuenta con los siguientes endpoints 

La api intenta simular lo que seria una bliblioteca de libros en donde podemos realizar las operaciones basicas CRUD create , read, update , delete
la api fue hecha con C# y utiliza Dapper como ORM a la vez que utiliza sql server como base de datos

Endpoints (Servicios) de la API de Libros

1. Obtener todos los libros
Método: GET
Ruta: /api/Books
Descripción: Este endpoint te permite obtener una lista de todos los libros disponibles en la base de datos. Es útil para mostrar una lista completa de libros.

2. Obtener un libro por ID
Método: GET
Ruta: /api/Books/{id}
Descripción: Utiliza este endpoint para recuperar la información detallada de un libro específico basado en su ID. Proporciona el ID del libro en la URL y recibirás los detalles del libro correspondiente.

3. Agregar un nuevo libro
Método: POST
Ruta: /api/Books/
Descripción: Utiliza este endpoint para agregar un nuevo libro a la base de datos. Debes enviar los detalles del libro en el cuerpo de la solicitud en formato JSON. La API creará un nuevo registro de libro y devolverá los detalles del libro recién creado, incluyendo su ID asignado.

4. Actualizar un libro existente
Método: PUT
Ruta: /api/Books/{id}
Descripción: Utiliza este endpoint para actualizar la información de un libro existente. Debes proporcionar el ID del libro que deseas actualizar en la URL y enviar los detalles actualizados en el cuerpo de la solicitud en formato JSON. La API modificará el registro del libro correspondiente con la nueva información y devolverá los detalles actualizados.

5. Eliminar un libro
Método: DELETE
Ruta: /api/Books/{id}
Descripción: Utiliza este endpoint para eliminar un libro de la base de datos. Proporciona el ID del libro que deseas eliminar en la URL. La API eliminará el registro del libro correspondiente y devolverá una respuesta exitosa.

