﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazethruApps
{
    public partial class formAwal : Form
    {
        List<double> wx;
        List<double> wy;
        int lap = 0;

        KendaliTombol kendali;
        public formAwal()
        {
            InitializeComponent();
            kendali = new KendaliTombol();

            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);

            wx[0] = 870; //lokasi awal
            wy[0] = 600;

            kendali.TambahTombol(btnUser, new FungsiTombol(TombolUserTekan));

            kendali.Start();
        }

        void TombolUserTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                formUser FormUser = new formUser();
                FormUser.Show();
                this.Hide();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void formAwal_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnUser.Location = new Point((int)wx[0], (int)wy[0]);

            if (lap == 0) //titik awal
            {
                wx[0]++;         
            }

            if (lap == 1) //titik akhir, balik
            {
                wx[0]--;
            }

            if (wx[0] == 1000)
            {
                lap = 1; //titik akhir
            }

            if (wx[0] == 770)
            {
                lap = 0;
            }

            kendali.CekTombol();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            formUser FormUser = new formUser();
            FormUser.Show();
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin LoginAdmin = new AdminLogin();
            LoginAdmin.Show();
            this.Hide();
        }

        private void buttonAdmin2_Click(object sender, EventArgs e)
        {
            //AdminLogin LoginAdmin = new AdminLogin();
            //LoginAdmin.Show();
            AdminAwal test = new AdminAwal();
            test.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }           
}

