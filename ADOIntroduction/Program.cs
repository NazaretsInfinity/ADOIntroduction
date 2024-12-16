using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Contexts;

namespace ADOIntroduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int padding = 30; //for text alignment

            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Library; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            Console.WriteLine(connectionString);
            Console.WriteLine("---------------------------");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

#if Authors
            string cmd = "SELECT * FROM Authors";
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();



            for (int i = 0; i < reader.FieldCount; ++i)
                Console.Write(reader.GetName(i).PadRight(padding));
            Console.WriteLine();

            if (!reader.IsClosed)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; ++i)
                    {
                        Console.Write(reader[i].ToString().PadRight(padding));
                    }
                    Console.WriteLine();
                }
            }
            reader.Close();
            connection.Close(); 
#endif
            string cmd = "SELECT book_title          AS \"Book name\"," +
                         " FORMATMESSAGE('%s %s', last_name, first_name)         AS \"Author\"" +
                         " FROM Books, Authors " +
                         "WHERE author = author_id";
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write(reader.GetName(i).PadRight(padding));
            Console.WriteLine("\n");
            Console.ResetColor();

            if(!reader.IsClosed)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; ++i)
                        Console.Write(reader[i].ToString().PadRight(padding));
                    Console.WriteLine();
                }
                
            }
            reader.Close(); 
            connection.Close();
        }
    }
}
