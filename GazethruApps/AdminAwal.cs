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
    public partial class AdminAwal : Form
    {
        //private readonly formAwal _Home;

        public AdminAwal()
        {
            InitializeComponent();
            //_Home = Home;
            Sidepanel.Height = btn_Slideshow.Height;
            Sidepanel.Top = btn_Slideshow.Top;
            if (!panelUC.Controls.Contains(AdminSlideshow.Instance))
            {
                panelUC.Controls.Add(AdminSlideshow.Instance);
                AdminSlideshow.Instance.Dock = DockStyle.Fill;
                AdminSlideshow.Instance.BringToFront();
                AdminSlideshow Slideshow = new AdminSlideshow();
                Slideshow.SlideList("");
            }
            else
                AdminSlideshow.Instance.BringToFront();
        }

        private void btn_Slideshow_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btn_Slideshow.Height;
            Sidepanel.Top = btn_Slideshow.Top;
            //adminSlideshow1.BringToFront();
            //AdminSlideshow Slideshow = new AdminSlideshow();
            //Slideshow.SlideList("");
            if (!panelUC.Controls.Contains(AdminSlideshow.Instance))
            {
                panelUC.Controls.Add(AdminSlideshow.Instance);
                AdminSlideshow.Instance.Dock = DockStyle.Fill;
                AdminSlideshow.Instance.BringToFront();
                AdminSlideshow Slideshow = new AdminSlideshow();
                Slideshow.SlideList("");
            }
            else
                AdminSlideshow.Instance.BringToFront();
        }

        private void btn_Tentang_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btn_Tentang.Height;
            Sidepanel.Top = btn_Tentang.Top;
            //adminInformasi1.BringToFront();
            //AdminInformasi Tentang = new AdminInformasi();
            //Tentang.InfoContent("");
            if (!panelUC.Controls.Contains(AdminInformasi.Instance))
            {
                panelUC.Controls.Add(AdminInformasi.Instance);
                AdminInformasi.Instance.Dock = DockStyle.Fill;
                AdminInformasi.Instance.BringToFront();
                AdminInformasi Tentang = new AdminInformasi();
                Tentang.InfoContent("");
            }
            else
                AdminInformasi.Instance.BringToFront();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            formAwal Home = new formAwal();
            Home.Show();
            this.Hide();
        }
    }
}
