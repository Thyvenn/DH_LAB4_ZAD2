using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Zadanie2
{
    public class DBconect
    {

        IDbConnection _conn1;

        public DBconect(string f_connstring)
        {
            _conn1 = new SqlConnection(f_connstring);
        }

        //wyswietlanie
        public IEnumerable<Klienci> Display()
        {
            return _conn1.Query<Klienci>("SELECT * FROM dbo.Klienci ");
        }


        public void Wyswietlanie()
        {
            foreach (Klienci x in Display())
            {
                Console.WriteLine($"IDklienta: {x.IDklienta}");
            }

            Console.WriteLine("\n");
        }

        //insert
        public void Insertowanie()
        {
            Klienci k1 = new Klienci();
            Console.WriteLine("Podaj IDklienta: ");
            k1.IDklienta = Console.ReadLine();
            Console.WriteLine("Podaj NazwaFirmy: ");
            k1.NazwaFirmy = Console.ReadLine();
            Console.WriteLine("Podaj Przedstawiciel: ");
            k1.Przedstawiciel = Console.ReadLine();
            Console.WriteLine("Podaj StanowiskoPrzedstawiciela: ");
            k1.StanowiskoPrzedstawiciela = Console.ReadLine();
            Console.WriteLine("Podaj Adres: ");
            k1.Adres = Console.ReadLine();

            _conn1.Execute("insert into Klienci(IDklienta,NazwaFirmy,Przedstawiciel,StanowiskoPrzedstawiciela,Adres) " +
                            $"values(@ID_klienta,@Nazwa_Firmy,@Przedstawiciel,@StanowiskoPrzedstawiciela,@Adres)"
                            , new { ID_klienta = k1.IDklienta, Nazwa_Firmy = k1.NazwaFirmy, Przedstawiciel = k1.Przedstawiciel,
                                StanowiskoPrzedstawiciela = k1.StanowiskoPrzedstawiciela, Adres = k1.Adres });
            Wyswietlanie();
            Console.WriteLine($"Dodano klienta");


        }

        public void Updateowanie()
        {
            Console.WriteLine("Podaj IDklienta");
            string zamiana_id = Console.ReadLine();
            Console.WriteLine("Podaj na jakie ID ma to byc zmienione");
            string nowe_id = Console.ReadLine();


            _conn1.Execute($"UPDATE Klienci SET IDklienta = @nowe_ID WHERE IDklienta = @zamiana_ID", new {nowe_ID = nowe_id, zamiana_ID = zamiana_id });
            Wyswietlanie();
            Console.WriteLine($"Zmieniono klienta o ID: {zamiana_id} na: {nowe_id}");

        }

        public void Deletowanie()
        {
            Console.WriteLine("Podaj IDklienta od usuniencia");
            string usun_id = Console.ReadLine();

            _conn1.Execute($"DELETE FROM Klienci WHERE IDklienta = @usun_ID", new { usun_ID = usun_id });
            Wyswietlanie();
            Console.WriteLine($"Usunięto klienta o ID: {usun_id}");

        }



    }

}

