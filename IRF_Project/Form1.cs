﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        List<Pilota> pilotak = new List<Pilota>(); //összes pilótának
        List<Szorzok> szorzok = new List<Szorzok>(); //összes pilótának
        List<Kategoria> kategoriak = new List<Kategoria>(); //csak aki legalább egy kategoriának megfelel
        public Form1()
        {
            InitializeComponent();
        }
    }
}
