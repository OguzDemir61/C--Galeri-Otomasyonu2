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
    public partial class frmaracalim : Form
    {
        public frmaracalim()
        {
            InitializeComponent();
        }
        public void AracAlimEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into aracsatis(AracAlisAracMarka,AracAlisModel,AracAlisMYili,AracAlisAracTipi,AracAlisAracTur,AracAlisPlaka,AracAlisSatıcıAdı,AracAlisTramer,AracAlisTelefonNo,AracAlisAlımYapanPersonel,AracAlisFiyat,AracAlisTarih) Values(@AracAlisAracMarka,@AracAlisModel,@AracAlisMYili,@AracAlisAracTipi,@AracAlisAracTur,@AracAlisSatıcıAdı,@AracAlisTramer,@AracAlisTelefonNo,@AracAlisAlımYapanPersonel,@AracAlisFiyat,@AracAlisTarih)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@AracAlisAracMarka", cmbMarka.Text);
                EkleKomut.Parameters.AddWithValue("@AracAlisModel", txtAracModel.Text);
                EkleKomut.Parameters.AddWithValue("@AracAlisMYili", textMyili.Text);
                EkleKomut.Parameters.AddWithValue("@AracAlisAracTur",cmbAracTur.Text);
                EkleKomut.Parameters.AddWithValue("@AracAlisTarih", dtDtar.Value.ToShortDateString());
                EkleKomut.Parameters.AddWithValue("@AracAlisSatıcıAdı", TxtSsaticiSoyad.Text);
                EkleKomut.Parameters.AddWithValue("@AracAlisTramer",textTramer.Text );
                EkleKomut.Parameters.AddWithValue("@AracAlisTelefonNo", txtTel.Text);
                EkleKomut.Parameters.AddWithValue("@AracAlisAlımYapanPersonel", txtAliciSoyad.Text);
                EkleKomut.Parameters.AddWithValue("@AracAlisFiyat", textFiyat.Text);
                EkleKomut.Parameters.AddWithValue("@AracAlisPlaka", txtPlaka.Text);
                if (radSedan.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracAlisAracTipi", radSedan.Text);
                else if (radHatbck.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracAlisAracTipi", radHatbck.Text);
                else if (radCoup.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracAlisAracTipi", radCoup.Text);
                else if (radSuv.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracAlisAracTipi", radSuv.Text);
                else if (radCab.Checked)
                    EkleKomut.Parameters.AddWithValue("@AracAlisAracTipi", radCab.Text);
                if (EkleKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtAliciSoyad.Text + " " + " İsimli Kişiye Aracımız Satılmıştır");
                frmAnaSayfa.baglanti.Close();

                
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Araç Alış ekle Hata Penceresi");

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
            txtAliciSoyad.BackColor = Color.White;
            TxtSsaticiSoyad.BackColor = Color.White;
            txtTel.BackColor = Color.White;
            cmbMarka.BackColor = Color.White;
            txtAracModel.BackColor = Color.White;
            textMyili.BackColor = Color.White;
            textFiyat.BackColor = Color.White;
            textTramer.BackColor = Color.White;


            if (textTramer.Text == "")
            {
                textTramer.BackColor = Color.Red;
                textTramer.Focus();
                bos = true;
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
            if (textFiyat.Text == "")
            {
                textFiyat.BackColor = Color.Red;
                textFiyat.Focus();
                bos = true;
            }
            if (txtAliciSoyad.Text == "")
            {
                txtAliciSoyad.BackColor = Color.Red;
                txtAliciSoyad.Focus();
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
            if (TxtSsaticiSoyad.Text == "")
            {
                TxtSsaticiSoyad.BackColor = Color.Red;
                TxtSsaticiSoyad.Focus();
                bos = true;
            }
            if (textMyili.Text == "")
            {
                textMyili.BackColor = Color.Red;
                textMyili.Focus();
                bos = true;
            }
            if (txtAracModel.Text == "")
            {
                txtAracModel.BackColor = Color.Red;
                txtAracModel.Focus();
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
                AracAlimEkle();
        }
    

        private void cmbAracTur_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radHatbck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (BoslukKontrol() == true)
                MessageBox.Show("Boş Alanları Doldurunuz", "Dikkat");
            else
                AracAlimEkle();
        }

        private void frmaracalim_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
