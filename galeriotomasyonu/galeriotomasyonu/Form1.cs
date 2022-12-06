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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt.accdb");


        public void AracSatisEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into aracsatis(AracSatisPlaka,AracSatisAlıcı,AracSatisAlıcıTelNo,AracSatisSatanPersonel,AracSatisTarih,AracSatisSatisFiyati,AracSatisFiyatAciklamasi,AracSatisTramer,AracSatisMarka,AracSatisModel,AracSatisAracTipi) Values(@AracSatisPlaka,@AracSatisAlıcı,@AracSatisAlıcıTelNo,@AracSatisSatanPersonel,@AracSatisTarih,@AracSatisSatisFiyati,@AracSatisFiyatAciklamasi,@AracSatisTramer,@AracSatisMarka,@AracSatisModel,@AracSatisAracTipi)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@AracSatisPlaka", txtAracPlaka.Text);
                EkleKomut.Parameters.AddWithValue("@AracSatisAlıcı", txtAliciSoyad.Text);
                EkleKomut.Parameters.AddWithValue("@AracSatisAlıcıTelNo", txtTel.Text);
                EkleKomut.Parameters.AddWithValue("@AracSatisSatanPersonel", TxtSsaticiSoyad);
                EkleKomut.Parameters.AddWithValue("@AracSatisTarih", dtDtar.Value.ToShortDateString());
                EkleKomut.Parameters.AddWithValue("@AracSatisSatisFiyati", textBox2.Text);
                EkleKomut.Parameters.AddWithValue("@AracSatisFiyatAciklamasi", textBox3.Text);
                EkleKomut.Parameters.AddWithValue("@AracSatisTramer", textBox4.Text);
                EkleKomut.Parameters.AddWithValue("@AracSatisMarka", comboBox2.Text);
                EkleKomut.Parameters.AddWithValue("@AracSatisModel", textBox1.Text);
                if (radSedan.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracSatisAracTipi", radSedan.Text);
                else if (radHatbck.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracSatisAracTipi", radHatbck.Text);
                else if (radCoup.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracSatisAracTipi", radCoup.Text);
                else if (radSuv.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracSatisAracTipi", radSuv.Text);
                else if (radCab.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracSatisAracTipi", radCab.Text);
                if (EkleKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtAliciSoyad.Text + " " + " İsimli Kişiye Aracımız Satılmıştır");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Araç Satış ekle Hata Penceresi");

            }
        }
        public bool BoslukKontrol()
        {
            bool bos = false;

            txtAracPlaka.BackColor = Color.White;
            radSedan.BackColor = Color.White;
            radCab.BackColor = Color.White;
            radSuv.BackColor = Color.White;
            radCoup.BackColor = Color.White;
            radHatbck.BackColor = Color.White;
            txtAliciSoyad.BackColor = Color.White;
            TxtSsaticiSoyad.BackColor = Color.White;
            txtTel.BackColor = Color.White;
            comboBox2.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            

            if (textBox3.Text == "")
            {
                textBox3.BackColor = Color.Red;
                textBox3.Focus();
            }

            if (radSedan.Checked == false && radCab.Checked == false && radSuv.Checked == false && radCoup.Checked == false && radHatbck.Checked == false)
            {
                radSedan.BackColor = Color.Red;
                radCab.BackColor = Color.Red;
                radSuv.BackColor = Color.Red;
                radCoup.BackColor = Color.Red;
                radHatbck.BackColor = Color.Red;
                bos = true;
            }
            if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.Red;
                textBox2.Focus();
            }
            if (txtAliciSoyad.Text == "")
            {
                txtAliciSoyad.BackColor = Color.Red;
                txtAliciSoyad.Focus();
            }
            if (txtTel.Text == "(   )    -" || txtTel.Text.Length < 14)
            {
                txtTel.BackColor = Color.Red;
                txtTel.Focus();
            }
            if (comboBox2.Text == "Marka Seçiniz" || comboBox2.Text == "")
            {
                comboBox2.BackColor = Color.Red;
                comboBox2.Focus();
            }
            if (TxtSsaticiSoyad.Text == "")
            {
                TxtSsaticiSoyad.BackColor = Color.Red;
                TxtSsaticiSoyad.Focus();
            }
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
            }
            if (textBox4.Text == "")
            {
                textBox4.BackColor = Color.Red;
                textBox4.Focus();
            }
            if (txtAracPlaka.Text == "")
            {
                txtAracPlaka.BackColor = Color.Red;
                txtAracPlaka.Focus();

            }
            
            return bos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BoslukKontrol() == true)
                MessageBox.Show("Boş Alanları Doldurunuz", "Dikkat");
            else
                AracSatisEkle();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (BoslukKontrol() == true)
                MessageBox.Show("Boş Alanları Doldurunuz", "Dikkat");
            else
                AracSatisEkle();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            {
                DialogResult cevap;

                cevap = MessageBox.Show("Programdan Çıkmak İstiyor Musunuz?", "Çıkış", MessageBoxButtons.YesNo);

                if (cevap == DialogResult.Yes)
                {

                    this.Close();
                }
                else
                    MessageBox.Show("Programa Geri Dönülüyor!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
