using System;
using System.Collections.Generic;
using System.Text;

namespace PLD_pizzafutár
{
    internal class Cim
    {
        private int id;

        private string nev;
        private string utca;
        private string hazszam;

        public Cim(int id, string nev, string utca, string hazszam)
        {
            this.id = id;
            this.nev = nev;
            this.utca = utca;
            this.hazszam = hazszam;
        }

        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Utca { get => utca; set => utca = value; }
        public string Hazszam { get => hazszam; set => hazszam = value; }

        public override string ToString()
        {
            return $"{nev}, {utca} {hazszam}";
        }
    }
}
