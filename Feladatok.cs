using K4os.Compression.LZ4.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using ZstdSharp.Unsafe;

namespace PLD_pizzafutár
{
    internal class Feladatok
    {
        private List<Rendeles> rendelesek;

        public Feladatok()
        {
            // rendelesek = new List<Rendeles>;
            Adatbazis adatbazis = new Adatbazis();
            rendelesek = new List<Rendeles>();
            rendelesek = adatbazis.feltolt();

        }

        public void Kiir()
        {
            foreach (var item in rendelesek)
            {
                Console.WriteLine(item);
            }
        }

        public void F03()
        {
            Console.WriteLine("----------\nFeladat 3\n---------");
            var lista = rendelesek.Select(r => r.Pizza).Where(p => p.Ar < 1500).Distinct().OrderByDescending(p => p.Meret).ThenBy(p => p.Nev).ToList();
            lista.ForEach(p => Console.WriteLine(p.ToString()));
            
        }

        public void F04()
        {
            Console.WriteLine("----------\nFeladat 4\n---------");
            //Milyen nevű és milyen méretű pizzából kellett a legtöbbet sütni az összes alapján?
            //Adja meg lekérdezés segítségével a pizza nevét, méretét és a darabszámát!
            var Legangyobb_ertek = rendelesek.Max(r => r.Db);
            var keresett = rendelesek.Where(r => r.Db ==  Legangyobb_ertek).Select(r => r.Pizza).ToList();
            keresett.ForEach(p => Console.WriteLine(p));

        }

        public void F05()
        {
            Console.WriteLine("----------\nFeladat 5\n---------");
            var lista = rendelesek.Where(r => r.Ido.Hours >= 18 && r.Ido.Hours <= 19).ToList();
            var darab = lista.Sum(r => r.Db);
            var kiszalitas = lista.Select(r => r.Pizza).ToList();
            kiszalitas.ForEach(p => Console.WriteLine(p));
            Console.WriteLine($"18 és 19 óra közötti pizzák száma: {darab}");

        }

        public void F06()
        {
            //?
        }

        public void F07()
        {
            Console.WriteLine("----------\nFeladat 7\n---------");
            var cimek = rendelesek.Select(r => r.Cim).Distinct().ToList();
            foreach (var cim in cimek) {
                var idoPont = rendelesek.Where(r => r.Cim == cim).Select(r => r.Ido).Distinct().ToList();
                foreach(var ido in idoPont)
                {
                    var szamlalas = rendelesek.Where(r => r.Cim == cim).Where(r => r.Ido == ido).Count();
                    if(szamlalas >= 3)
                    {
                        Console.WriteLine($"{ido} | {cim} | igyen üditöt kap!");
                    }
                }
            }
        }
    }
}
