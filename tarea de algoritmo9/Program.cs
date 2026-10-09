using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

public class Program
{
    private const string cadenaConexion =
        @"Server=(localdb)\GastosTarea;Database=GastosDB;Integrated Security=True;";
    public static void Main(string[] args)
    {
        List<Gasto> listaGastos = new List<Gasto>();
        decimal totalGastado = 0;

        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            conexion.Open();

            string consulta = "SELECT Id, Descripcion, Monto, Categoria FROM Gastos";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Gasto gasto = new Gasto();

                        gasto.Id = lector.GetInt32(0);
                        gasto.Descripcion = lector.GetString(1);
                        gasto.Monto = lector.GetDecimal(2);
                        gasto.Categoria = lector.GetString(3);

                        listaGastos.Add(gasto);
                    }
                }
            }
        }

        if (listaGastos.Count == 0)
        {
            Console.WriteLine("No hay gastos registrados.");
        }
        else
        {
            Console.WriteLine("=== GASTOS REGISTRADOS ===");

            for (int i = 0; i < listaGastos.Count; i++)
            {
                Console.WriteLine(listaGastos[i].ToString());
                totalGastado = totalGastado + listaGastos[i].Monto;
            }

            Console.WriteLine();
            Console.WriteLine($"TOTAL GASTADO: Q {totalGastado:N2}");
        }

        Console.WriteLine();
        Console.WriteLine("Presiona una tecla para cerrar.");
        Console.ReadKey();
    }
}