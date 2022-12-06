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
    public partial class frmAracMarkaTanımlama : Form
    {
        public frmAracMarkaTanımlama()
        {
            InitializeComponent();
        }

        public void BirimListele()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from AracMarkaTanımlama";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, frmAnaSayfa.baglanti);
                da.Fill(ds, "AracMarkaTanımlama");
                dataGridView1.DataSource = ds.Tables["AracMarkaTanımlama"];
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Araç Marka Listele Hata Penceresi");
            }
        }

        public void BirimEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into AracMarkaTanımlama (Marka) Values(@Marka)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@Marka", txtBAdi.Text);


                if (EkleKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Yeni Marka Eklendi");

                }

                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Araç Marka Ekleme Hata Penceresi");

            }
        }

        public void BirimSil()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Delete from AracMarkaTanımlama Where MarkaKod=" + txtBKod.Text;
                OleDbCommand SilKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                if (SilKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtBKod.Text + " " + "Nolu Marka Silindi");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Araç Marka Silme hata Penceresi");
            }
        }

        public void BirimDegistir()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Update AracMarkaTanımlama set Marka=@Marka Where MarkaKod=@MarkaKod";
                OleDbCommand DegistirKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);

                DegistirKomut.Parameters.AddWithValue("@Marka", txtBAdi.Text);
                DegistirKomut.Parameters.AddWithValue("@MarkaKod", txtBKod.Text);

                if (DegistirKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtBKod.Text + " " + " Nolu Marka Güncellendi");

                }
                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Araç Marka Güncelle Hata Penceresi");

            }
        }


        private void frmAracMarkaTanımlama_Load(object sender, EventArgs e)
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
                MessageBox.Show("Araç Markasını yazınız");
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
                MessageBox.Show("Silinecek Markayı Seçiniz");
            }
            else
            {
                if (MessageBox.Show(txtBKod.Text + " Nolu Marka Silinecek\nOnaylıyor Musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    BirimSil();
                    BirimListele();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtBKod.Text == "")
                MessageBox.Show("Güncelenecek Araç Markasını Seçiniz");
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtBKod.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtBAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
