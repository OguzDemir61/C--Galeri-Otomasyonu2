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
    public partial class frmGiderlerTanımlama : Form
    {
        public frmGiderlerTanımlama()
        {
            InitializeComponent();
        }
        public void BirimListele()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from GiderlerTanımlama";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, frmAnaSayfa.baglanti);
                da.Fill(ds, "GiderlerTanımlama");
                dataGridView1.DataSource = ds.Tables["GiderlerTanımlama"];
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Gider Tanımlama Listele Hata Penceresi");
            }
        }

        public void BirimEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into GiderlerTanımlama (GiderAdi) Values(@GiderAdi)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@GiderAdi", txtGAdi.Text);


                if (EkleKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Yeni Gider Eklendi");

                }

                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Gider Ekleme Hata Penceresi");

            }
        }

        public void BirimSil()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Delete from GiderlerTanımlama Where Kimlik=" + txtGKod.Text;
                OleDbCommand SilKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                if (SilKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtGKod.Text + " " + "Nolu Gider Silindi");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Gider Silme hata Penceresi");
            }
        }

        public void BirimDegistir()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Update GiderlerTanımlama set GiderAdi=@GiderAdi Where Kimlik=@Kimlik";
                OleDbCommand DegistirKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);

                DegistirKomut.Parameters.AddWithValue("@GiderAdi", txtGAdi.Text);
                DegistirKomut.Parameters.AddWithValue("@Kimlik", txtGKod.Text);

                if (DegistirKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtGKod.Text + " " + " Nolu Gider Güncellendi");

                }
                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Gider Güncelle Hata Penceresi");

            }
        }





        private void frmGiderlerTanımlama_Load(object sender, EventArgs e)
        {
            BirimListele();
        }

        private void brnEkle_Click(object sender, EventArgs e)
        {
            if (txtGKod.Text != "")
            {
                MessageBox.Show("Temizle butonuna basınız.");
                btnTemizle.Focus();
            }
            else if (txtGAdi.Text == "")
            {
                MessageBox.Show("Gider Türünü yazınız");
                txtGAdi.Focus();
            }
            else
            {
                BirimEkle();
                BirimListele();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtGKod.Text == "")
            {
                MessageBox.Show("Silinecek Gider Türünü Seçiniz");
            }
            else
            {
                if (MessageBox.Show(txtGKod.Text + " Nolu Gider Türü Silinecek\nOnaylıyor Musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    BirimSil();
                    BirimListele();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtGKod.Text == "")
                MessageBox.Show("Güncelenecek Gider Türünü Seçiniz");
            else
            {
                BirimDegistir();
                BirimListele();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtGKod.Text = "";
            txtGAdi.Text = "";
            txtGAdi.Focus();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtGKod.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtGAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }

}
