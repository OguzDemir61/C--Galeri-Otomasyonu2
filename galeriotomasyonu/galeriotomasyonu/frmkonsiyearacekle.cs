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
    public partial class frmkonsiyearacekle : Form
    {
        public frmkonsiyearacekle()
        {
            InitializeComponent();
        }
        public void KonsiyeAracEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into konsiye(KonsiyeAracMarka,KonsiyeAracModel,KonsiyeModelYil,KonsiyePlaka,KonsiyeKm,KonsiyeKonsiyeFiyat,KonsiyeSatisFiyati,KonsiyeKonsiyeSahibi,KonsiyeYakitTuru,KonsiyeTelefonNo,KonsiyeTarih) Values(@KonsiyeAracMarka,@KonsiyeAracModel,@KonsiyeModelYil,@KonsiyePlaka,@KonsiyeKm,@KonsiyeKonsiyeFiyat,@KonsiyeSatisFiyati,@KonsiyeKonsiyeSahibi,@KonsiyeYakitTuru,@KonsiyeTelefonNo,@KonsiyeTarih)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@KonsiyePlaka", txtPlaka.Text);
                EkleKomut.Parameters.AddWithValue("@KonsiyeYakitTuru", txtYakit.Text);
                EkleKomut.Parameters.AddWithValue("@KonsiyeAracModel", txtAracModel.Text);
                EkleKomut.Parameters.AddWithValue("@KonsiyeModelYil", txtMyili.Text);
                EkleKomut.Parameters.AddWithValue("@KonsiyeTarih", dtDtar.Value.ToShortDateString());
                EkleKomut.Parameters.AddWithValue("@KonsiyeKonsiyeFiyat", txtAlisFiyat.Text);
                EkleKomut.Parameters.AddWithValue("@KonsiyeSatisFiyati", txtSatisFiyat.Text);
                EkleKomut.Parameters.AddWithValue("@KonsiyeKm", txtKm.Text);
                EkleKomut.Parameters.AddWithValue("@KonsiyeAracMarka", cmbMarka.Text);
                EkleKomut.Parameters.AddWithValue("@KonsiyeKonsiyeSahibi", textBox1.Text);
                if (radSedan.Checked)
                    EkleKomut.Parameters.AddWithValue("@KonsiyeAracTipi", radSedan.Text);
                else if (radHatbck.Checked)
                    EkleKomut.Parameters.AddWithValue("@KonsiyeAracTipi", radHatbck.Text);
                else if (radCoup.Checked)
                    EkleKomut.Parameters.AddWithValue("@KonsiyeAracTipi", radCoup.Text);
                else if (radSuv.Checked)
                    EkleKomut.Parameters.AddWithValue("@KonsiyeAracTipi", radSuv.Text);
                else if (radCab.Checked)
                    EkleKomut.Parameters.AddWithValue("@KonsiyeAracTipi", radCab.Text);
                if (EkleKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtPlaka.Text + " " + " Plakalı Araç Konsiye Araçlara Eklenmiştir.");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Konsiye Araç ekle Hata Penceresi");
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
            textBox1.BackColor = Color.White;

            if (txtKm.Text == "")
            {
                txtKm.BackColor = Color.Red;
                txtKm.Focus();
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
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
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
                KonsiyeAracEkle();
        }

        private void frmkonsiyearacekle_FormClosed(object sender, FormClosedEventArgs e)
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
