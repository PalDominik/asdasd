using System;
using System.Collections.Generic;
using System.Text;

namespace PLD_pizzafutár
{
    internal class Rendeles
    {
        private int id;
        private Pizza pizza;
        private Cim cim;
        private int db;

        private TimeSpan ido;

        public Rendeles(int id, Pizza pizza, Cim cim, int db, TimeSpan ido)
        {
            this.id = id;
            this.pizza = pizza;
            this.cim = cim;
            this.db = db;
            this.ido = ido;
        }

        public int Id { get => id; set => id = value; }
        public int Db { get => db; set => db = value; }
        public TimeSpan Ido { get => ido; set => ido = value; }
        internal Pizza Pizza { get => pizza; set => pizza = value; }
        internal Cim Cim { get => cim; set => cim = value; }

        public override string ToString()
        {
            return $"({pizza.ToString()}) x {db} | Helyszin: {cim.ToString()}";
        }
    }
}
