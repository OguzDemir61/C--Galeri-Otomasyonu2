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
    public partial class frmaracstoksil : Form
    {
        public frmaracstoksil()
        {
            InitializeComponent();
        }
        public void AracStokSil()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "delete from aracbilgileri where SiraNo=" + txtID.Text;
                OleDbCommand SilKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                if (SilKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtID.Text + " ID'li Kayıt Silindi");
                }
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Araç Stok Sil Hata Penceresi");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show(txtID.Text + " ID'li Kayıt Silinecektir.\nOnaylıyor Musunuz?", "Kayıt silme onay", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (cevap == DialogResult.Yes)
            {
                AracStokSil();
                this.Close();
            }
        }

        private void frmaracstoksil_FormClosed(object sender, FormClosedEventArgs e)
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
