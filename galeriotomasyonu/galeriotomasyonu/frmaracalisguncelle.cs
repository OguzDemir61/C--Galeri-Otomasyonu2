using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace galeriotomasyonu
{
    public partial class frmaracalisguncelle : Form
    {
        public frmaracalisguncelle()
        {
            InitializeComponent();
        }

        private void frmaracalisguncelle_FormClosed(object sender, FormClosedEventArgs e)
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
