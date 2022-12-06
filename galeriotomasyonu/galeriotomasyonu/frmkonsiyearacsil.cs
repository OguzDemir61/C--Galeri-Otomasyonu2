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
    public partial class frmkonsiyearacsil : Form
    {
        public frmkonsiyearacsil()
        {
            InitializeComponent();
        }
        public void KonsiyeAracsil()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "delete from konsiye where Kimlik=" + txtID.Text;
                OleDbCommand SilKomut = new OleDbCommand(Sorgu, frmAnaSayfa.baglanti);
                if (SilKomut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtID.Text + " ID'li Kayıt Silindi");
                }
                frmAnaSayfa.baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Konsiye Araç Sil Hata Penceresi");
            }
        }
        public bool BoslukKontrol()
        {
            bool bos = false;

            txtID.BackColor = Color.White;
            txtPlaka.BackColor = Color.White;
            txtModel.BackColor = Color.White;
            cmbMarka.BackColor = Color.White;
            if (txtModel.Text == "")
            {
                txtModel.BackColor = Color.Red;
                txtModel.Focus();
                bos = true;
            }
            if (cmbMarka.Text == "Marka Seçiniz" || cmbMarka.Text == "")
            {
                cmbMarka.BackColor = Color.Red;
                cmbMarka.Focus();
                bos = true;
            }
            if (txtPlaka.Text == "")
            {
                txtPlaka.BackColor = Color.Red;
                txtPlaka.Focus();
                bos = true;
            }
            if (txtID.Text == "")
            {
                txtID.BackColor = Color.Red;
                txtID.Focus();
                bos = true;
            }
            return bos;
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            if (BoslukKontrol() == true)
                MessageBox.Show("Boş Alanları Doldurunuz", "Dikkat");
            else
            {
                DialogResult cevap;
                cevap = MessageBox.Show(txtID.Text + " ID'li Kayıt Silinecektir.\nOnaylıyor Musunuz?", "Kayıt silme onay", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (cevap == DialogResult.Yes)
                {
                    KonsiyeAracsil();
                    this.Close();
                }
            }
        }

        private void frmkonsiyearacsil_FormClosed(object sender, FormClosedEventArgs e)
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