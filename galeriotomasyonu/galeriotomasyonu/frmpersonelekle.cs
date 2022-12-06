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
    public partial class frmpersonelekle : Form
    {
        public frmpersonelekle()
        {
            InitializeComponent();
        }
        public void PersonelEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into Personel(Personelİsim,PersonelDYer,PersonelBirim,PersonelMaas,PersonelBankaAdi,PersonelIBAN,PersonelTCno,PersonelCeptlf,PersonelKullaniciAdi,PersonelSifre,PersonelDtar,PersonelCinsiyet) Values(@Personelİsim,@PersonelDYer,@PersonelBirim,@PersonelMaas,@PersonelBankaAdi,@PersonelIBAN,@PersonelTCno,@PersonelCeptlf,@PersonelKullaniciAdi,@PersonelSifre,PersonelDtar,PersonelCinsiyet)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@Personelİsim", txtAd.Text);
                EkleKomut.Parameters.AddWithValue("@PersonelDYer", cmbDyer.Text);
                EkleKomut.Parameters.AddWithValue("@PersonelBirim", cmbBirim.Text);
                EkleKomut.Parameters.AddWithValue("@PersonelMaas", txtMaas.Text);
                EkleKomut.Parameters.AddWithValue("@PersonelDtar", dtDtar.Value.ToShortDateString());
                EkleKomut.Parameters.AddWithValue("@PersonelBankaAdi", txtBanka.Text);
                EkleKomut.Parameters.AddWithValue("@PersonelIBAN", maskedTextBox1.Text);
                EkleKomut.Parameters.AddWithValue("@PersonelTCno", txtTcno.Text);
                EkleKomut.Parameters.AddWithValue("@PersonelCeptlf", txtTel.Text);
                EkleKomut.Parameters.AddWithValue("@PersonelKullaniciAdi", TxtKad.Text);
                EkleKomut.Parameters.AddWithValue("@PersonelSifre", txtSifre.Text);
                if (radErkek.Checked)
                    EkleKomut.Parameters.AddWithValue("@PersonelCinsiyet", radErkek.Text);
                else if (radKadın.Checked)
                    EkleKomut.Parameters.AddWithValue("@PersonelCinsiyet", radKadın.Text);        
                if (EkleKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtAd.Text + " " + " Adlı Personel Eklenmiştir.");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel ekle Hata Penceresi");
            }
        }
        public bool BoslukKontrol()
        {
            bool bos = false;

            txtAd.BackColor = Color.White;
            radErkek.BackColor = Color.White;
            radKadın.BackColor = Color.White;
            cmbBirim.BackColor = Color.White;
            txtMaas.BackColor = Color.White;
            txtTel.BackColor = Color.White;
            cmbDyer.BackColor = Color.White;
            txtBanka.BackColor = Color.White;
            maskedTextBox1.BackColor = Color.White;
            txtTcno.BackColor = Color.White;
            TxtKad.BackColor = Color.White;
            txtSifre.BackColor = Color.White;

            if (txtAd.Text == "")
            {
                txtAd.BackColor = Color.Red;
                txtAd.Focus();
                bos = true;
            }

            if (radErkek.Checked == false && radKadın.Checked == false)
            {
                radErkek.BackColor = Color.Red;
                radKadın.BackColor = Color.Red;
                bos = true;
            }
            if (txtMaas.Text == "")
            {
                txtMaas.BackColor = Color.Red;
                txtMaas.Focus();
                bos = true;
            }
            if (txtBanka.Text == "")
            {
                txtBanka.BackColor = Color.Red;
                txtBanka.Focus();
                bos = true;
            }
            if (txtTel.Text == "(   )    -" || txtTel.Text.Length < 14)
            {
                txtTel.BackColor = Color.Red;
                txtTel.Focus();
                bos = true;
            }
            if (cmbDyer.Text == "Şehir Seçiniz" || cmbDyer.Text == "")
            {
                cmbDyer.BackColor = Color.Red;
                cmbDyer.Focus();
                bos = true;
            }
            if (cmbBirim.Text == "Birim Seçiniz" || cmbDyer.Text == "")
            {
                cmbBirim.BackColor = Color.Red;
                cmbBirim.Focus();
                bos = true;
            }
            if (txtTel.Text == "")
            {
                txtTel.BackColor = Color.Red;
                txtTel.Focus();
                bos = true;
            }
            if (txtSifre.Text == "")
            {
                txtSifre.BackColor = Color.Red;
                txtSifre.Focus();
                bos = true;
            }
            if (TxtKad.Text == "")
            {
                TxtKad.BackColor = Color.Red;
                TxtKad.Focus();
                bos = true;
            }
            if (txtAd.Text == "")
            {
                txtAd.BackColor = Color.Red;
                txtAd.Focus();
                bos = true;
            }
            if (txtTcno.Text == "")
            {
                txtTcno.BackColor = Color.Red;
                txtTcno.Focus();
                bos = true;

            }

            return bos;
        }

        public void BirimYukle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Select BirimAdi from Birimler";
                OleDbCommand Yuklekomut = new OleDbCommand(Sorgu, Form1.baglanti);
                OleDbDataReader dr = Yuklekomut.ExecuteReader();
                while (dr.Read())
                {
                    cmbBirim.Items.Add(dr["BirimAdi"]);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Birim Yükle Hata Penceresi!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (BoslukKontrol() == true)
                MessageBox.Show("Boş Alanları Doldurunuz", "Dikkat");
            else
                PersonelEkle();
        }

        private void frmpersonelekle_FormClosed(object sender, FormClosedEventArgs e)
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

        private void cmbBirim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
