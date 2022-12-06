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
    public partial class frmPersonelİsimTanımlama : Form
    {
        public frmPersonelİsimTanımlama()
        {
            InitializeComponent();
        }

        public void BirimListele()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from Personelİsim";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, frmAnaSayfa.baglanti);
                da.Fill(ds, "Personelİsim");
                dataGridView1.DataSource = ds.Tables["Personelİsim"];
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Personel İsim Listele Hata Penceresi");
            }
        }

        public void BirimEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into Personelİsim (PersonelAd) Values(@PersonelAd)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@PersonelAd", txtBAdi.Text);


                if (EkleKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Yeni Personel İsmi Eklendi");

                }

                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel İsim Ekleme Hata Penceresi");

            }
        }

        public void BirimSil()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Delete from Personelİsim Where Kimlik=" + txtBKod.Text;
                OleDbCommand SilKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                if (SilKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtBKod.Text + " " + "Nolu İsim Silindi");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Personel İsim Silme hata Penceresi");
            }
        }

        public void BirimDegistir()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Update Birimler set BirimAdi=@BirimAdi Where Kimlik=@Kimlik";
                OleDbCommand DegistirKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);

                DegistirKomut.Parameters.AddWithValue("@BirimAdi", txtBAdi.Text);
                DegistirKomut.Parameters.AddWithValue("@Kimlik", txtBKod.Text);

                if (DegistirKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtBKod.Text + " " + " Nolu Personel Güncellendi");

                }
                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel İsim Güncelle Hata Penceresi");

            }
        }




        private void frmPersonelİsimTanımlama_Load(object sender, EventArgs e)
        {
            
            BirimListele();

        }

        private void brnEkle_Click(object sender, EventArgs e)
        {
            if (txtBKod.Text != "")
            {
                MessageBox.Show("Temizle butonuna basınız.");
                btnTemizle.Focus();
            }
            else if (txtBAdi.Text == "")
            {
                MessageBox.Show("Personel İsmini yazınız");
                txtBAdi.Focus();
            }
            else
            {
                BirimEkle();
                BirimListele();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtBKod.Text == "")
            {
                MessageBox.Show("Silinecek İsmi Seçiniz");
            }
            else
            {
                if (MessageBox.Show(txtBKod.Text + " Nolu Personel İsim Silinecek\nOnaylıyor Musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    BirimSil();
                    BirimListele();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtBKod.Text == "")
                MessageBox.Show("Güncelenecek Birimi Seçiniz");
            else
            {
                BirimDegistir();
                BirimListele();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtBKod.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtBAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }


        private void btnTemizle_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtBKod.Text = "";
            txtBAdi.Text = "";
            txtBAdi.Focus();
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            txtBKod.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtBAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void txtBKod_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
