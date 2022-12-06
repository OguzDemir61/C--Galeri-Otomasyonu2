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
    public partial class frmaracstokekle : Form
    {
        public frmaracstokekle()
        {
            InitializeComponent();
        }
        public void AracStokEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into aracbilgileri(Plaka,AracMarkasi,AracModeli,ModelYili,DevirTarihi,AracTipi,AlısFiyati,SatisFiyati,AracKm,YakitTuru) Values(@Plaka,@AracMarkasi,@AracModeli,@ModelYili,@DevirTarihi,@AracTipi,@AlısFiyati,@SatisFiyati,@AracKm,@YakitTuru)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@Plaka", txtPlaka.Text);
                EkleKomut.Parameters.AddWithValue("@YakitTuru", txtYakit.Text);
                EkleKomut.Parameters.AddWithValue("@AracModeli", txtAracModel.Text);
                EkleKomut.Parameters.AddWithValue("@ModelYili", txtMyili.Text);
                EkleKomut.Parameters.AddWithValue("@DevirTarihi", dtDtar.Value.ToShortDateString());
                EkleKomut.Parameters.AddWithValue("@AlısFiyati", txtAlisFiyat.Text);
                EkleKomut.Parameters.AddWithValue("@SatisFiyati", txtSatisFiyat.Text);
                EkleKomut.Parameters.AddWithValue("@AracKm", txtKm.Text);
                EkleKomut.Parameters.AddWithValue("@AracMarkasi", cmbMarka.Text);

                if (radSedan.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracTipi", radSedan.Text);
                else if (radHatbck.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracTipi", radHatbck.Text);
                else if (radCoup.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracTipi", radCoup.Text);
                else if (radSuv.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracTipi", radSuv.Text);
                else if (radCab.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracTipi", radCab.Text);
                if (EkleKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtPlaka.Text + " " + " Plakalı Araç Stoklara Eklenmiştir");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Araç Stok ekle Hata Penceresi");
            }
        }
            public bool BoslukKontrol()
        {
            bool bos = false;

            txtPlaka.BackColor = Color.White;
            radSedan.BackColor = Color.White;
            radCab.BackColor = Color.White;
            radSuv.BackColor = Color.White;
            radCoup.BackColor = Color.White;
            radHatbck.BackColor = Color.White;
            txtYakit.BackColor = Color.White;
            txtAracModel.BackColor = Color.White;
            txtTel.BackColor = Color.White;
            cmbMarka.BackColor = Color.White;
            txtMyili.BackColor = Color.White;
            txtAlisFiyat.BackColor = Color.White;
            txtSatisFiyat.BackColor = Color.White;
            txtKm.BackColor = Color.White;


            if (txtKm.Text == "")
            {
                txtKm.BackColor = Color.Red;
                txtKm.Focus();
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
            if (txtSatisFiyat.Text == "")
            {
                txtSatisFiyat.BackColor = Color.Red;
                txtSatisFiyat.Focus();
                bos = true;
            }
            if (txtAlisFiyat.Text == "")
            {
                txtAlisFiyat.BackColor = Color.Red;
                txtAlisFiyat.Focus();
                bos = true;
            }
            if (txtTel.Text == "(   )    -" || txtTel.Text.Length < 14)
            {
                txtTel.BackColor = Color.Red;
                txtTel.Focus();
                bos = true;
            }
            if (cmbMarka.Text == "Marka Seçiniz" || cmbMarka.Text == "")
            {
                cmbMarka.BackColor = Color.Red;
                cmbMarka.Focus();
                bos = true;
            }
            if (txtMyili.Text == "")
            {
                txtMyili.BackColor = Color.Red;
                txtMyili.Focus();
                bos = true;
            }
            if (txtAracModel.Text == "")
            {
                txtAracModel.BackColor = Color.Red;
                txtAracModel.Focus();
                bos = true;
            }
            if (txtYakit.Text == "")
            {
                txtYakit.BackColor = Color.Red;
                txtYakit.Focus();
                bos = true;
            }
            if (txtPlaka.Text == "")
            {
                txtPlaka.BackColor = Color.Red;
                txtPlaka.Focus();
                bos = true;
            }
            
            return bos;
        }

            private void button1_Click(object sender, EventArgs e)
            {
                if (BoslukKontrol() == true)
                    MessageBox.Show("Boş Alanları Doldurunuz", "Dikkat");
                else
                    AracStokEkle();
            }

            private void frmaracstokekle_FormClosed(object sender, FormClosedEventArgs e)
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

        private void frmaracstokekle_Load(object sender, EventArgs e)
        {

        }
    }

    }

