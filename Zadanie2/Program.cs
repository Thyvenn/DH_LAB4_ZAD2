using System;
using Dapper;

namespace Zadanie2
{
    class Program
    {

        static void Main(string[] args)
        {
           
            //łączenie z bazą danych
            string conString = @"Data Source=DESKTOP-UK1AL1K;Initial Catalog=ZNorthwind_Kopia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var db1 = new DBconect(conString);

            db1.Wyswietlanie();
            db1.Insertowanie();
            db1.Updateowanie();
            db1.Deletowanie();
           
           



            Console.ReadLine();
            
            




            //k1.display();
            //k1.insert();
            //k1.update();
            //k1.delete();
            //k1.closeconn();

        }
    }
}
