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
    public partial class frmPersonelÖdemeBilgileri : Form
    {
        public frmPersonelÖdemeBilgileri()
        {
            InitializeComponent();
        }

        public static OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vt.accdb");

        public static void BaglantiAc()
        {
            try
            {
                baglanti.Open();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Bağlantı Açma Hata Penceresi");
            }
        }

        public void PersonelÖdemeListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from PersonelIban";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "PersonelIban");
                dataGridView1.DataSource = ds.Tables["PersonelIban"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel Iban Listele Hata Penceresi");

            }
        }

        public void PersonelÖdemeSil()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Delete from PersonelIban Where Id=" + txtPId.Text;
                OleDbCommand SilKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                if (SilKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtPId.Text + " " + "Nolu İban Silindi");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Personel İban Silme hata Penceresi");
            }
        }

        public void PersonelÖdemeDegistir()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Update PersonelIban set PersonelIban=@PersonelIban Where Id=@Id";
                OleDbCommand DegistirKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);


                DegistirKomut.Parameters.AddWithValue("@PersonelIban", maskedTextBox1.Text);
                DegistirKomut.Parameters.AddWithValue("@Id", txtPId.Text);

                if (DegistirKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtPId.Text + " " + " Nolu İban Tutarı Güncellendi");

                }
                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel İban Güncelle Hata Penceresi");

            }
        }


        private void frmPersonelÖdemeBilgileri_Load(object sender, EventArgs e)
        {
            PersonelÖdemeListele();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtPId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtPId.Text == "")
            {
                MessageBox.Show("Silinecek İbanı Seçiniz");
            }
            else
            {
                if (MessageBox.Show(txtPId.Text + " Nolu Personel İban Silinecek\nOnaylıyor Musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    PersonelÖdemeSil();
                    PersonelÖdemeListele();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtPId.Text == "")
                MessageBox.Show("Güncelenecek Maaşı Seçiniz");
            else
            {

                PersonelÖdemeDegistir();
                PersonelÖdemeListele();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtPId.Text = "";
            txtPAdi.Text = "";
            maskedTextBox1.Text = "";
            txtPAdi.Focus();
            txtPAdi.Focus();
        }
    }
}
