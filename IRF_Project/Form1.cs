using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRF_Project.Entities;

namespace IRF_Project
{
    public partial class Form1 : Form
    {
        Database1Entities2 context = new Database1Entities2();
        List<Pilot> pilots = new List<Pilot>();
        //List<Place> places = new List<Place>();
        List<Pilota> pilotak = new List<Pilota>(); //gyengéket leszámítva mindenki (nincs legjobb 15-beli eredménye)
        List<Szorzok> szorzok = new List<Szorzok>(); //gyengéket leszámítva mindenki
        List<Kategoria> kategoriak = new List<Kategoria>(); //csak aki legalább egy kategoriának megfelel
        public Form1()
        {
            InitializeComponent();
            //context.Pilots.Load();
            //context.Places.Load();
            pilots = context.Pilots.ToList();
            //places = context.Places.ToList<Place>();
            Feltoltes();
            MessageBox.Show(pilotak.Count.ToString());
            Osztalyozas();
            Kategorizal();
            MessageBox.Show(kategoriak.Count.ToString());
        }

        private void Feltoltes()
        {
            for (int i = 0; i < pilots.Count; i++)
            {
                if ((pilots[i].C18f2 == 0 || pilots[i].C18f2 > 16) &&
                    (pilots[i].C19f2 == 0 || pilots[i].C19f2 > 16) &&
                    (pilots[i].C20f2 == 0 || pilots[i].C20f2 > 16) &&
                    (pilots[i].C18f3 == 0 || pilots[i].C18f3 > 16) &&
                    (pilots[i].C19f3 == 0 || pilots[i].C19f3 > 16) &&
                    (pilots[i].C20f3 == 0 || pilots[i].C20f3 > 16) &&
                    (pilots[i].C18g3 == 0 || pilots[i].C18g3 > 16) &&
                    (pilots[i].C18fe == 0 || pilots[i].C18fe > 16) &&
                    (pilots[i].C19fe == 0 || pilots[i].C19fe > 16) &&
                    (pilots[i].C20fe == 0 || pilots[i].C20fe > 16))
                {
                    if (pilots[i].egyéb!=1)
                    {
                        continue;
                    }
                    
                }
                if(pilots[i].Kor==0)
                { continue; }
                Pilota P = new Pilota();
                P.Nev = pilots[i].Név;
                P.Nem = (int)pilots[i].Nem;
                P.Kor = (int)pilots[i].Kor;
                P.Pontszam = (int)(pilots[i].Place.f2+ pilots[i].Place1.f2 + pilots[i].Place2.f2 +
                     pilots[i].Place3.f3 + pilots[i].Place4.f3 + pilots[i].Place5.f3 +
                      pilots[i].Place6.gp3 + pilots[i].Place7.fe + pilots[i].Place8.fe +
                       pilots[i].Place9.fe);
                if (P.Pontszam<40&&pilots[i].egyéb==1)
                {
                    P.Pontszam = 40;
                }
                P.Szerzodes = (int)pilots[i].szerződés;
                P.Verseny = (int)pilots[i].verseny;
                P.Teszt = (int)pilots[i].teszt;
                pilotak.Add(P);
            }
        }
        private void Osztalyozas()
        {
            for (int i = 0; i < pilotak.Count; i++)
            {
                Szorzok sz = new Szorzok();
                sz.Nev = pilotak[i].Nev;
                if (pilotak[i].Nem==1)
                {
                    sz.Nem = 1;
                }
                else
                { sz.Nem = 1.2; }

                if (pilotak[i].Kor==0)
                {
                    sz.Kor = 0;
                }
                else if (pilotak[i].Kor<18)
                {
                    sz.Kor = 1.5;
                }
                else if (pilotak[i].Kor < 21)
                {
                    sz.Kor = 1.3;
                }
                else if (pilotak[i].Kor < 25)
                {
                    sz.Kor = 1;
                }
                else if (pilotak[i].Kor < 32)
                {
                    sz.Kor = 0.8;
                }
                else if (pilotak[i].Kor < 36)
                {
                    sz.Kor = 0.5;
                }
                else
                {
                    sz.Kor = 0.2;
                }

                if (pilotak[i].Verseny==1)
                {
                    sz.Tapasztalat = 1.5;
                }
                else if (pilotak[i].Teszt==1)
                {
                    sz.Tapasztalat = 1.3;
                }
                else
                {
                    sz.Tapasztalat = 1;
                }
                sz.Pontszam = pilotak[i].Pontszam;
                szorzok.Add(sz);
            }
        }
        private void Kategorizal()
        {
            for (int i = 0; i < szorzok.Count; i++)
            {
                Kategoria k = new Kategoria();
                k.Nev = szorzok[i].Nev;
                k.Ertekeles = (1 + szorzok[i].Pontszam) * szorzok[i].Nem*szorzok[i].Kor*szorzok[i].Tapasztalat;
                if ((k.Ertekeles<3&&szorzok[i].Kor==1.5)||(k.Ertekeles<5&&szorzok[i].Kor==1.3)||(k.Ertekeles<10))
                {
                    continue;
                }
                if(szorzok[i].Kor > 1)
                {
                    k.Junior = true;
                }
                else
                {
                    k.Junior = false;
                }
                if (k.Ertekeles>20||szorzok[i].Tapasztalat>1)
                {
                    k.Tesztpilota = true;
                }
                else
                {
                    k.Tesztpilota = false;
                }
                if(szorzok[i].Pontszam>=40&&k.Ertekeles>=40&&szorzok[i].Kor<1.5)
                {
                    k.Versenyzo = true;
                }
                else
                {
                    k.Versenyzo = true;
                }
                if(!k.Junior&&!k.Tesztpilota&&!k.Versenyzo)
                {
                    continue;
                }
                else
                {
                    kategoriak.Add(k);
                }
            }
        }
    }
}
