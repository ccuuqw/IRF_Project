using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project.Entities
{
    public class Pilota
    {
        public string Nev { get; set; }
        public int Nem { get; set; }
        public int Kor { get; set; }
        public int Pontszam { get; set; }
        public int Szerzodes { get; set; }
        public int Verseny { get; set; }
        public int Teszt { get; set; }
        public bool ValidatePilota(int pontszam, int legjobb, int egyeb, int szerzodes)
        {
            //szerzodes: van már szerződése
            //pontszám: eredményekből számítva a fő programban
            //legjobb: legalacsonyabb nem 0 helyezés egy bajnokságban
            //egyeb: más eredménynek köszönhetően megszerzi a 40 pontot
            //kritérium: pontszam legalább egy, vagy van legalább top 15-ös helyezése, vagy egyéb=1, akkor igaz, különben hamis, nem vesszük fel a pilotak listába
            //ha van már szerződése, szintén nem foglalkozunk vele
            if(szerzodes==1)
            {
                return false;
            }
                if (egyeb==1)
            {
                return true;
            }
            else if (pontszam>0)
            {
                return true;
            }
            else if (legjobb<=15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
