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
        public bool ValidateVersenyzo(double kor, int pontszam, double tapasztalat, double nem)
        {
            //ha a pontszáma és a szorzókból előállított eredménye is legalább 40, versenyzőjelölt
            double eredmeny = (1 + pontszam) * nem * kor * tapasztalat;
            if (pontszam>=40&& eredmeny>=40)
            { return true; }
            return false;
        }
        public bool ValidateTesztpilota(double kor, int pontszam, double tapasztalat, double nem)
        {
            //ha legalább 20 a szorzókból előállított eredménye, vagy már tesztelt/versenyzett korábban F1-ben, tesztpilóta jelölt
            double eredmeny = (1 + pontszam) * nem * kor * tapasztalat;
            if (eredmeny >= 20||tapasztalat>1)
            { return true; }
            return false;
        }
        public bool ValidateJunior(double kor, int pontszam, double tapasztalat, double nem)
        {
            //ha 18-20 évesként legalább 5, vagy 18 év alattiként legalább 3 a szorzókból előállított eredménye, junior jelölt
            double eredmeny = (1 + pontszam) * nem * kor * tapasztalat;
            if ((eredmeny >= 5 && kor == 1.3) || (eredmeny >= 3 && kor == 1.5))
            { return true; }
            return false;
        }
        public bool ValidateKategoriak(double kor, int pontszam, double tapasztalat, double nem)
        {
            //ha legalább az egyik kategóriába bekerült, felvesszük a végső javaslati listába
            return ValidateVersenyzo(kor, pontszam,tapasztalat,nem)||ValidateTesztpilota(kor, pontszam, tapasztalat, nem)||ValidateJunior(kor, pontszam, tapasztalat, nem);
        }
    }
}
