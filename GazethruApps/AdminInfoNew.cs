﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GazethruApps
{
    public partial class AdminInfoNew : Form
    {
        public AdminInfoNew()
        {
            InitializeComponent();
        }

        public static int infoIDlast;
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aliefya\source\repos\GazeThru00\GazethruApps\GazeThruDB.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection con = new SqlConnection(connectionString);

        private void buttonBrowsePict_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG; *.PNG; *.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void AdminInfoNew_Load(object sender, EventArgs e)
        {
            //NewInfoContent();
        }

        public void GetLastID()
        {

            con.Open();
            string SelectQuery = "SELECT No FROM Info WHERE No = SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataAdapter adapter = new SqlDataAdapter(SelectQuery, con);

            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                NoInfo.Text = (read["No"].ToString());
            }
            else
            {
                textBoxJudul.Text = "";

            }

            con.Close();
        }


        private void buttonInsert_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            SqlCommand command = new SqlCommand("INSERT INTO Info(Judul, Isi, Gambar) VALUES (@judul , @isi, @gambar)", con);

            command.Parameters.Add("@judul", SqlDbType.VarChar).Value = textBoxJudul.Text;
            command.Parameters.Add("@isi", SqlDbType.VarChar).Value = textBoxIsi.Text;
            command.Parameters.Add("@gambar", SqlDbType.Image).Value = img;

            ExecMyQuery(command, "Data Inserted");
        }

        public void ExecMyQuery(SqlCommand mcomd, string myMsg)
        {
            con.Open();
            if (mcomd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg);
            }
            else
            {
                MessageBox.Show("Query Not Executed");
            }

            con.Close();
            this.Close();
            //??
            AdminInformasi load = new AdminInformasi();
            load.InfoContent("");

        }
    }
}
