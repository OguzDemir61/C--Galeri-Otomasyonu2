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
    public partial class frmFinalUygulama : Form
    {
        public frmFinalUygulama()
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

        public void FinalListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from Final";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "Final");
                dataGridView1.DataSource = ds.Tables["Final"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Final Listele Hata Penceresi");

            }
        }

       


        public void BirimEkle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Insert Into Final (FinalAd) Values(@FinalAd)";
                OleDbCommand EkleKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                EkleKomut.Parameters.AddWithValue("@FinalAd", txtAd.Text);


                if (EkleKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Yeni Final Ad Eklendi");

                }

                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Final Ad  Ekleme Hata Penceresi");

            }
        }

        public void BirimSil()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Delete from Final Where id=" + txtİd.Text;
                OleDbCommand SilKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                if (SilKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(txtİd.Text + " " + "Nolu Kişi  Silindi");
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Final Kişi Silme hata Penceresi");
            }
        }

        public void BirimDegistir()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Update Final set FinalAd=@FinalAd Where id=@id";
                OleDbCommand DegistirKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);

                DegistirKomut.Parameters.AddWithValue("@GiderAdi", txtAd.Text);
                DegistirKomut.Parameters.AddWithValue("@Kimlik", txtİd.Text);

                if (DegistirKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtİd.Text + " " + " Nolu Final Kişi Güncellendi");

                }
                frmAnaSayfa.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Final Kişi Güncelle Hata Penceresi");

            }
        }

        public void BirimYukle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Select FinalBölüm from Final";
                OleDbCommand Yuklekomut = new OleDbCommand(Sorgu,baglanti);
                OleDbDataReader dr = Yuklekomut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["FinalBölüm"]);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Birim Yükle Hata Penceresi!");
            }
        }


        private void frmFinalUygulama_Load(object sender, EventArgs e)
        {
            
            FinalListele();
          
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            txtİd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyAd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();            
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtİd.Text != "")
            {
                MessageBox.Show("Temizle butonuna basınız.");
                btnTemizle.Focus();
            }
            else if (txtAd.Text == "")
            {
                MessageBox.Show("Kişi Türünü yazınız");
                txtAd.Focus();
            }
            else
            {
                BirimEkle();
                FinalListele();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (txtİd.Text == "")
            {
                MessageBox.Show("Silinecek Final Türünü Seçiniz");
            }
            else
            {
                if (MessageBox.Show(txtİd.Text + " Nolu Gider Türü Silinecek\nOnaylıyor Musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    BirimSil();
                    FinalListele();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtİd.Text == "")
                MessageBox.Show("Güncelenecek Gider Türünü Seçiniz");
            else
            {
                BirimDegistir();
                FinalListele();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            txtİd.Text = "";
            txtAd.Text = "";
            txtAd.Focus();
        }


        
        private void txtFinalHizliAra_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
