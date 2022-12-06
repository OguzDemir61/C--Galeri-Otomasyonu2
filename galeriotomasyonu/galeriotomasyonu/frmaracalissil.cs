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
    public partial class frmaracalissil : Form
    {
        public frmaracalissil()
        {
            InitializeComponent();
        }
        public void AracAlıssil()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "delete from aracalis where Kimlik=" + txtID.Text;
                OleDbCommand SilKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                if (SilKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtID.Text + " ID'li Kayıt Silindi");
                }
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Araç Alış Sil Hata Penceresi");
            }
        }

        private void frmaracalissil_Load(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show(txtID.Text + " ID'li Kayıt Silinecektir.\nOnaylıyor Musunuz?", "Kayıt silme onay", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (cevap == DialogResult.Yes)
            {
                AracAlıssil();
                this.Close();
            }
        }

        private void frmaracalissil_FormClosed(object sender, FormClosedEventArgs e)
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
