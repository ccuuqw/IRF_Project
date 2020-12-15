using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project
{
    public partial class Form1 : Form
    {
        Database1Entities2 context = new Database1Entities2();
        public Form1()
        {
            InitializeComponent();
        }
        public void Feltoltes()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Filter = "Comma Seperated Values (*.csv)|*.csv";
            ofd.DefaultExt = "csv";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() != DialogResult.OK) return;

            using (StreamReader sr = new StreamReader(ofd.FileName, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(';');
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0: //CsapatÉv
                            try
                            {
                                Pilot p = new Pilot();
                                p.PilotId = int.Parse(sor[17]);
                                p.Név = sor[0];
                                try { p.Nem = int.Parse(sor[1]); } catch { }
                                try { p.Kor = int.Parse(sor[2]); } catch { }
                                try { p.C18f2 = int.Parse(sor[3]); } catch { }
                                try { p.C19f2 = int.Parse(sor[4]); } catch { }
                                try { p.C20f2 = int.Parse(sor[5]); } catch { }
                                try { p.C18f3 = int.Parse(sor[6]); } catch { }
                                try { p.C19f3 = int.Parse(sor[7]); } catch { }
                                try { p.C20f3 = int.Parse(sor[8]); } catch { }
                                try { p.C18g3 = int.Parse(sor[9]); } catch { }
                                try { p.C18fe = int.Parse(sor[10]); } catch { }
                                try { p.C19fe = int.Parse(sor[11]); } catch { }
                                try { p.C20fe = int.Parse(sor[12]); } catch { }
                                try { p.egyéb = int.Parse(sor[13]); } catch { }
                                try { p.szerződés = int.Parse(sor[14]); } catch { }
                                try { p.verseny = int.Parse(sor[15]); } catch { }
                                try { p.teszt = int.Parse(sor[16]); } catch { }

                                context.Pilots.Add(p);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Nem megfelelő a .csv fájl tartalma!\n" + ex.Message);
                                sr.Close();
                                goto EndWhile1;
                            }


                            break;
                        case 1: //PilótaÉv
                            try
                            {
                                Place p = new Place();
                                try { p.PlaceId = int.Parse(sor[0]); } catch { }
                                try { p.f2 = int.Parse(sor[1]); } catch { }
                                try { p.f3 = int.Parse(sor[2]); } catch { }
                                try { p.gp3 = int.Parse(sor[3]); } catch { }
                                try { p.fe = int.Parse(sor[4]); } catch { }
                                context.Places.Add(p);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Nem megfelelő a .csv fájl tartalma!\n" + ex.Message);
                                sr.Close();
                                goto EndWhile2;
                            }
                            break;
                    }
                    //try
                    //{
                    //    context.SaveChanges();

                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}
                }
                try
                {
                    context.SaveChanges();

                    MessageBox.Show("Sikerült az adatfelvétel.");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            EndWhile1:;
            EndWhile2:;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex!=-1)
            {
                Feltoltes();
            }
            
        }
    }
}
