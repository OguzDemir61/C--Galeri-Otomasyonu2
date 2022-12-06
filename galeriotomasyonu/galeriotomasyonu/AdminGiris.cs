using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace galeriotomasyonu
{
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbDataReader dr;

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void AdminGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            {
                DialogResult cevap;

                cevap = MessageBox.Show("Programdan Çıkmak İstiyor Musunuz?", "Çıkış", MessageBoxButtons.YesNo);

                if (cevap == DialogResult.Yes)
                {

                    Application.Exit();
                }
                else
                    MessageBox.Show("Programa Geri Dönülüyor!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                DialogResult cevap;

                cevap = MessageBox.Show("Programdan Çıkmak İstiyor Musunuz?", "Çıkış", MessageBoxButtons.YesNo);

                if (cevap == DialogResult.Yes)
                {

                    Application.Exit();
                }
                else
                    MessageBox.Show("Programa Geri Dönülüyor!");
            }
        }
        int hak = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string sifre = textBox2.Text;
            frmAnaSayfa.baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt.accdb");
            cmd = new OleDbCommand();
            frmAnaSayfa.baglanti.Open();
            cmd.Connection = frmAnaSayfa.baglanti;
            cmd.CommandText = "Select * from admin where KullaniciAdi='" + textBox1.Text + "'AND Sifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                frmAnaSayfa frm6 = new frmAnaSayfa();
                frm6.Show();
                this.Hide();
                frmAnaSayfa.baglanti.Close();

            }
            else
            {
                hak--;
                if (hak > 0)
                    lblMesaj.Text = "Kullanıcı Adı veya Şifre Hatalı\nKalan Hakkınız:" + hak;
                else
                {
                    MessageBox.Show("Hakkınzı Bitti\nProgram Kapatılıyor");
                    frmAnaSayfa.baglanti.Close();


                }
            }
            }
        }
    }


