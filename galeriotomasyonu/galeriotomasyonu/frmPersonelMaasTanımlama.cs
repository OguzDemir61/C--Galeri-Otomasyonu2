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
    public partial class frmPersonelMaasTanımlama : Form
    {
        public frmPersonelMaasTanımlama()
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




        public void PersonelMaaşListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from PersonelMaas";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "PersonelMaas");
                dataGridView1.DataSource = ds.Tables["PersonelMaas"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel Maaş Listele Hata Penceresi");

            }
        }

        public void PersonelMaasEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into PersonelMaas (Personelİsim) Values(@Personelİsim)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@PersonelAd", txtPAdi.Text);
                EkleKomut.Parameters.AddWithValue("@PersonelMaasTutar", txtMaas.Text);

                if (EkleKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Yeni Personel Maaş Bilgisi Eklendi");

                }

                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Yeni Personel Maaş Bilgisi Hata Penceresi");

            }
        }

        public void PersonelMaasSil()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Delete from PersonelMaas Where Id=" + txtPId.Text;
                OleDbCommand SilKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                if (SilKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtPId.Text + " " + "Nolu İsim Silindi");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Personel Maaş Silme hata Penceresi");
            }
        }

        public void PersonelMaasTutarDegistir()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Update PersonelMaas set PersonelMaasTutar=@PersonelMaasTutar Where Id=@Id";
                OleDbCommand DegistirKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);

                
                DegistirKomut.Parameters.AddWithValue("@PersonelMaasTutar", txtMaas.Text);
                DegistirKomut.Parameters.AddWithValue("@Id", txtPId.Text);
                
                if (DegistirKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtPId.Text + " " + " Nolu Maaş Tutarı Güncellendi");

                }
                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel Maaş Güncelle Hata Penceresi");

            }
        }



        private void frmPersonelMaasTanımlama_Load(object sender, EventArgs e)
        {
            PersonelMaaşListele();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtPId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtMaas.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void brnEkle_Click(object sender, EventArgs e)
        {
            if (txtPId.Text != "")
            {
                MessageBox.Show("Temizle butonuna basınız.");
                btnTemizle.Focus();
            }
            else if (txtPAdi.Text == "")
            {
                MessageBox.Show("Personel İsmini yazınız");
                txtPAdi.Focus();
            }
            else if (txtMaas.Text == "")
            {
                MessageBox.Show("Personel Maaş Tutarını yazınız");
                txtMaas.Focus();
            }
            else
            {
                PersonelMaasEkle();
                PersonelMaaşListele();
            }

            


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtPId.Text == "")
            {
                MessageBox.Show("Silinecek İsmi Seçiniz");
            }
            else
            {
                if (MessageBox.Show(txtPId.Text + " Nolu Personel İsim Silinecek\nOnaylıyor Musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    PersonelMaasSil();
                    PersonelMaaşListele();
                }
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtPId.Text = "";
            txtPAdi.Text = "";
            txtMaas.Text = "";
            txtPAdi.Focus();
            txtPAdi.Focus();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtPId.Text == "")
                MessageBox.Show("Güncelenecek Maaşı Seçiniz");
            else
            {

                PersonelMaasTutarDegistir();
                PersonelMaaşListele();
            }
        }

        private void txtMaas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

