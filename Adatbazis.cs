using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLD_pizzafutár
{
    internal class Adatbazis
    {
        private string connectionString;

        public Adatbazis()
        {
            this.connectionString = "server=localhost;database=pizzafutár;user=root;password='';";
            feltolt();
        }
        public List<Rendeles> feltolt()
        {
            List<Rendeles> rendelesek = new List<Rendeles>();
            Dictionary<int, Cim> cimek = new Dictionary<int, Cim>();
            Dictionary<int, Pizza> pizzak = new Dictionary<int, Pizza>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Adatbázis betöltése elkezdödött");
                    string query = "Select * FROM cim";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string nev = reader.GetString("nev");
                                string utca = reader.GetString("utca");
                                string hazszam = reader.GetString("hsz");
                                Cim cim = new Cim(id, nev, utca, hazszam);
                                cimek.Add(id, cim); //kulcs az id, value: a cím objektum
                            }
                        }
                    }

                    query = "Select * FROM pizza";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string nev = reader.GetString("nev");
                                int meret = reader.GetInt32("meret");
                                int ar = reader.GetInt32("ar");
                                Pizza pizza = new Pizza(id, nev, meret,ar);
                                pizzak.Add(id, pizza); //kulcs az id, value: a cím objektum
                            }
                        }
                    }

                    query = "Select * FROM rendeles";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                int pizzaId = reader.GetInt32("pizzaid");
                                int darab = reader.GetInt32("darab");
                                int cimId = reader.GetInt32("cimid");
                                TimeSpan ido = reader.GetTimeSpan("szallitas");
                                Pizza pizza = pizzak[pizzaId];
                                Cim cim = cimek[cimId];
                                Rendeles rendeles = new Rendeles(id,pizza,cim,darab,ido);
                                rendelesek.Add(rendeles);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gatya: " + ex);
            }


            return rendelesek;
        }
    }
}
