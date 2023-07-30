using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ödev_restorant1
{
    public partial class Form1 : Form
    {

        SqlConnection conn = new SqlConnection("server=.; initial catalog=RESTORANTDB;integrated security=sspi ");
        SqlCommand cmdD;
        SqlDataAdapter da;


        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";

        }

        void listele()

        {
            da = new SqlDataAdapter("select * from yemekler", conn);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;

            temizle();

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmdD = new SqlCommand("insert into yemekler(Masano,ÇORBA,ANAYEMEK,TATLI,SALATA,İÇECEK) values ('" + int.Parse(comboBox1.Text) + "', '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "' )", conn);
            conn.Open();
            cmdD.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Sipariş Alındı.");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmdD = new SqlCommand("update yemekler set Masano='" + int.Parse(comboBox1.Text) + "' , ÇORBA='" + textBox1.Text + "',ANAYEMEK='" + textBox2.Text + "',TATLI='" + textBox3.Text + "',SALATA='" + textBox4.Text + "',İÇECEK='" + textBox5.Text + "'where ID='" + int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'  ", conn);
            conn.Open();
            cmdD.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Sipariş GÜNCELLENDİ.");
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmdD = new SqlCommand("DELETE from yemekler where ID= '"+ int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())+"' ", conn);
            conn.Open();
            cmdD.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Sipariş SİLiNDİ.");
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from yemekler WHERE masano like '" + textBox6.Text + "%' ", conn);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;

            temizle();

        }
    }
}
