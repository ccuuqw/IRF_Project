using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project.Entities
{
    public class Kategoria
    {
        public string Nev { get; set; }
        public double Ertekeles { get; set; }
        public bool Versenyzo { get; set; }
        public bool Tesztpilota { get; set; }
        public bool Junior { get; set; }
    }
}
