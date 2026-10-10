# Conexión a GastosDB

## Descripción

Este proyecto es una aplicación de consola en C# que se conecta a la base de datos GastosDB, Lee los gastos guardados, los muestra en pantalla y calcula el total.

## Cómo ejecutar el programa

1. Abrir el proyecto en Visual Studio.
2. Revisar que LocalDB esté iniciado y que exista la base `GastosDB`.
3. Confirmar que la cadena de conexión de `Program.cs` use la instancia (localdb)\GastosTarea.
4. Ejecutar con Ctrl + F5.

Se necesita tener instalado el paquete Microsoft.Data.SqlClient.

## Archivos del proyecto

- Program.cs: conexión con SQL Server, lectura de los gastos y cálculo del total.
- Gasto.cs: clase que representa un gasto.
- CrearGastosDB.sql: script para crear la base de datos, la tabla y los gastos iniciales.

## Pruebas realizadas

### 1. Gastos iniciales

Se mostraron Almuerzo, Gasolina y Cine.

**Total:** Q 370.50

Prueba 1

### 2. Agregar un gasto

Se agregó Café por Q 12.00 desde una consulta SQL.

**Total:** Q 382.50

Prueba 2

### 3. Tabla vacía

Se ejecutó DELETE FROM Gastos

**Resultado:** No hay gastos registrados.

Prueba 3

### 4. Base de datos inexistente

Se cambió temporalmente el nombre de la base en la cadena de conexión por BaseQueNoExiste. El programa mostró una SqlException, como se esperaba. Después se volvió a colocar GastosDB.

Prueba 4
## Estudiante

Nombre: Luis Emir Monterroso
