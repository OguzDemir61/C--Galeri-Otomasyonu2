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
    public partial class frmBirimTanimlama : Form
    {
        public frmBirimTanimlama()
        {
            InitializeComponent();
        }

        

        public void BirimListele()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from Birimler";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, frmAnaSayfa.baglanti);
                da.Fill(ds, "Birimler");
                dataGridView1.DataSource = ds.Tables["Birimler"];
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Birim Listele Hata Penceresi");
            }
        }

        public void BirimEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into Birimler (BirimAdi) Values(@BirimAdi)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@BirimAdi", txtBAdi.Text);


                if (EkleKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Yeni Birim Eklendi");

                }

                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Kayıt Ekleme Hata Penceresi");

            }
        }

        public void BirimSil()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Delete from Birimler Where BirimKod=" + txtBKod.Text;
                OleDbCommand SilKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                if (SilKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtBKod.Text + " " + "Nolu Birim Silindi");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Birim Silme hata Penceresi");
            }
        }

        public void BirimDegistir()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Update Birimler set BirimAdi=@BirimAdi Where BirimKod=@BirimKod";
                OleDbCommand DegistirKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);

                DegistirKomut.Parameters.AddWithValue("@BirimAdi", txtBAdi.Text);
                DegistirKomut.Parameters.AddWithValue("@BirimKod", txtBKod.Text);

                if (DegistirKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtBKod.Text + " " + " Nolu Birim Güncellendi");

                }
                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Birim Güncelle Hata Penceresi");

            }
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {

            if (txtBKod.Text != "")
            {
                MessageBox.Show("Temizle butonuna basınız.");
                btnTemizle.Focus();
            }
            else if (txtBAdi.Text == "")
            {
                MessageBox.Show("Birim adını yazınız");
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
                MessageBox.Show("Silinecek Kaydı Seçiniz");
            }
            else
            {
                if (MessageBox.Show(txtBKod.Text + " Nolu Birim Silinecek\nOnaylıyor Musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtBKod.Text = "";
            txtBAdi.Text = "";
            txtBAdi.Focus();
        }

        private void frmBirimTanimlama_Load(object sender, EventArgs e)
        {
            BirimListele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtBKod.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtBAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
    }
}
