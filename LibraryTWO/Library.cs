using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.Design;



namespace LibraryTWO
{
    internal class Library
    {
        static readonly string delimeter2 = "\n===============================================\n";
        static readonly string delimeter1 = "\n-----------------------------------------------\n";
        static string connectionString = "";
        static SqlConnection connection = null;

        static Library()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
            connection = new SqlConnection(connectionString);
            Console.WriteLine(connectionString);
        }

        public static void Select(string fields, string tables, string condition = "", int padding = 20)
        {
            string cmd = $"SELECT {fields} FROM {tables}";
           if(condition.Length > 0)
           cmd += $" WHERE {condition}";
            cmd += ";";
            SqlCommand command = new SqlCommand(cmd, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                Console.WriteLine(delimeter2);
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < reader.FieldCount; ++i)
                    Console.Write(reader.GetName(i).PadRight(padding));
                Console.ResetColor();

                Console.WriteLine(delimeter1);
                while(reader.Read())
                {
                    for(int i =0; i < reader.FieldCount; ++i)
                        Console.Write(reader[i].ToString().PadRight(padding));
                    Console.WriteLine();
                }
                Console.WriteLine(delimeter2);
            }
            reader.Close();
            connection.Close();
        }
    }
}
