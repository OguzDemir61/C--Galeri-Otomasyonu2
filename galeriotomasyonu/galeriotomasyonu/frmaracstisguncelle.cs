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
    public partial class frmaracstisguncelle : Form
    {
        public frmaracstisguncelle()
        {
            InitializeComponent();
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
            txtID.BackColor = Color.White;
            txtTel.BackColor = Color.White;
            cmbMarka.BackColor = Color.White;
            txtAracModel.BackColor = Color.White;
            txtSatisFiyat.BackColor = Color.White;


            if (txtSatisFiyat.Text == "")
            {
                txtSatisFiyat.BackColor = Color.Red;
                txtSatisFiyat.Focus();
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
            if (txtID.Text == "")
            {
                txtID.BackColor = Color.Red;
                txtID.Focus();
                bos = true;

            }
            return bos;
        }
        public void AracSatisGuncelle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "update aracsatis set AracSatisplaka=@AracSatisplaka,AracSatisTarih=@AracSatisTarih,AracSatisSatisFiyati=@AracSatisSatisFiyati,AracSatisAlıcıTelNo=@AracSatisAlıcıTelNo,AracSatisModel=@AracSatisModel,AracSatisMarka=@AracSatisMarka,AracSatisAracTipi=@AracSatisAracTipi where Kimlik=@Kimlik";
                OleDbCommand DegistirKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                DegistirKomut.Parameters.AddWithValue("@Kimlik", txtID.Text);
                DegistirKomut.Parameters.AddWithValue("@AracSatisplaka", txtPlaka.Text);
                DegistirKomut.Parameters.AddWithValue("@AracSatisSatisFiyati", txtSatisFiyat.Text);
                if (radCab.Checked)
                    DegistirKomut.Parameters.AddWithValue("@AracSatisAracTipi", radCab.Text);
                else if (radCoup.Checked)
                    DegistirKomut.Parameters.AddWithValue("@AracSatisAracTipi", radCoup.Text);
                else if (radHatbck.Checked)
                    DegistirKomut.Parameters.AddWithValue("@AracSatisAracTipi", radHatbck.Text);
                else if (radSedan.Checked)
                    DegistirKomut.Parameters.AddWithValue("@AracSatisAracTipi", radSedan.Text);
                else if (radSuv.Checked)
                    DegistirKomut.Parameters.AddWithValue("@AracSatisAracTipi", radSuv.Text);
                DegistirKomut.Parameters.AddWithValue("@AracSatisMarka", cmbMarka.Text);
                DegistirKomut.Parameters.AddWithValue("@AracSatisTarih", dtDtar.Value.ToShortDateString());
                DegistirKomut.Parameters.AddWithValue("@AracSatisAlıcıTelNo", txtTel.Text);
                DegistirKomut.Parameters.AddWithValue("@AracSatisModel", txtAracModel.Text);
                DegistirKomut.Parameters.AddWithValue("@id", txtID.Text);
                if (DegistirKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtID.Text + " " + "  ID Numaralı Kayıt Değiştirildi");
                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Araç Satış Güncelle Hata Penceresi");

            }
        }


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndegis_Click(object sender, EventArgs e)
        {
            {
                if (BoslukKontrol() == true)
                    MessageBox.Show("Boş Alanları Doldurunuz", "Dikkat");
                else
                {
                    AracSatisGuncelle();
                    this.Close();
                }
            }
        }

        private void frmaracstisguncelle_FormClosed(object sender, FormClosedEventArgs e)
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