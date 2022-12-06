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
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
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

        public void BirimYukle()
        {
            try
            {
                frmAnaSayfa.BaglantiAc();
                string Sorgu = "Select BirimAdi from Birimler";
                OleDbCommand Yuklekomut = new OleDbCommand(Sorgu, Form1.baglanti);
                OleDbDataReader dr = Yuklekomut.ExecuteReader();
                while (dr.Read())
                {
                    cmbBirimAra.Items.Add(dr["BirimAdi"]);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Birim Yükle Hata Penceresi!");
            }
        }



        public void PersonelListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from personel";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "personel");
                dataGridView1.DataSource = ds.Tables["personel"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel Listele Hata Penceresi");
                
            }
        }

        public void AracListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from aracbilgileri";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "aracbilgileri");
                dataGridView1.DataSource = ds.Tables["aracbilgileri"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "aracbilgileri Listele Hata Penceresi");

            }
        }


        public void AracSatisListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from aracsatis";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "aracsatis");
                dataGridView1.DataSource = ds.Tables["aracsatis"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "AracSatisListele Listele Hata Penceresi");

            }
        }

        public void PersonelMaasListele()
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


        public void GelirListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from gelirler";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "gelirler");
                dataGridView1.DataSource = ds.Tables["gelirler"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Gelirler Listele Hata Penceresi");

            }
        }


        public void GiderListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from giderler";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "giderler");
                dataGridView1.DataSource = ds.Tables["giderler"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Giderler Listele Hata Penceresi");

            }
        }


        public void PersonelGiderListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from personelgider";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "personelgider");
                dataGridView1.DataSource = ds.Tables["personelgider"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel Giderler Listele Hata Penceresi");

            }
        }

        public void DukkanGiderListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from dukkangider";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "dukkangider");
                dataGridView1.DataSource = ds.Tables["dukkangider"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Dükkan Giderler Listele Hata Penceresi");

            }
        }

        public void TaksitÖdemeleriListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from sigorta";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "sigorta");
                dataGridView1.DataSource = ds.Tables["sigorta"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Taksit Ödeme Listele Hata Penceresi");

            }
        }


        public void SigortaGiderListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from sigorta";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "sigorta");
                dataGridView1.DataSource = ds.Tables["sigorta"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Sigorta Giderler Listele Hata Penceresi");

            }
        }

        public void AracAlisListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from aracalis";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "aracalis");
                dataGridView1.DataSource = ds.Tables["aracalis"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Arac Alıs Listele Hata Penceresi");

            }
        }

        public void KonsiyeListele()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguListele = "Select * from konsiye";
                OleDbDataAdapter da = new OleDbDataAdapter(SorguListele, baglanti);
                da.Fill(ds, "konsiye");
                dataGridView1.DataSource = ds.Tables["konsiye"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Konsiye Listele Hata Penceresi");

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



        public void PersonelKayitAra()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguTumKayitlar = "Select * from personel";

                string SorguAd = "Select * from personel where Personelİsim='" + txtAdAra.Text + "' ";
                string SorguTcNo = "Select * from personel where PersonelTCno='" + txtTcNoAra.Text + "' ";
                string SorguBirim = "Select * from personel where PersonelBirim='" + cmbBirimAra.Text + "' ";
                string SorguTlfNo = "Select * from personel where PersonelCeptlf='" + txtTlfNoAra.Text + "'";


                string SorguAdTcNo = "Select * from personel where Personelİsim='" + txtAdAra.Text + "' And PersonelTCno='" + txtTcNoAra.Text + "' ";
                string SorguAdBirim = "Select * from personel where Personelİsim='" + txtAdAra.Text + "' And PersonelBirim='" + cmbBirimAra.Text + "' ";
                string SorguTcNoBirim = "Select * from personel where PersonelTCno='" + txtTlfNoAra.Text + "' And PersonelBirim='" + cmbBirimAra.Text + "' ";

                string SorguAdTcNoBirim = "Select * from personel where Personelİsim='" + txtAdAra.Text + "' And PersonelTCno='" + txtTlfNoAra.Text + "' And PersonelBirim= '" + cmbBirimAra.Text + "' ";

                if (chkAd.Checked == true && chkSoyad.Checked == true && chkBirim.Checked == true)
                    SorguTumKayitlar = SorguAdTcNoBirim;

                else if (chkAd.Checked == true && chkSoyad.Checked == true)
                    SorguTumKayitlar = SorguAdTcNo;
                else if (chkAd.Checked == true && chkBirim.Checked == true)
                    SorguTumKayitlar = SorguAdBirim;
                else if (chkSoyad.Checked == true && chkBirim.Checked == true)
                    SorguTumKayitlar = SorguTcNoBirim;

                else if (chkAd.Checked == true)
                    SorguTumKayitlar = SorguAd;
                else if (chkSoyad.Checked == true)
                    SorguTumKayitlar = SorguTcNo;
                else if (chkBirim.Checked == true)
                    SorguTumKayitlar = SorguBirim;


                OleDbDataAdapter da = new OleDbDataAdapter(SorguTumKayitlar, baglanti);
                da.Fill(ds, "Personel");
                dataGridView1.DataSource = ds.Tables["Personel"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Kayit Arama Hata Penceresi");
            }
        }

        public void AracKayitAra()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguTumKayitlar = "Select * from aracbilgileri";

                string SorguAracMarka = "Select * from aracbilgileri where AracMarkasi='" + cmbMarkaAra.Text + "' ";
                string SorguAracModel = "Select * from aracbilgileri where AracModeli='" + txtModel.Text + "' ";
                string SorguAracModelYili = "Select * from aracbilgileri where ModelYili='" + txtMYılıAra.Text + "' ";
                

                string SorguAracMarkaAracModel = "Select * from aracbilgileri where AracMarkasi='" + cmbMarkaAra.Text + "' And AracModeli='" + txtModel.Text + "' ";
                string SorguAracMarkaAracModelYili = "Select * from aracbilgileri where AracMarkasi='" + cmbMarkaAra.Text + "' And AracModeli='" + txtModel.Text + "' ";
                string SorguAracModelAracModelYili = "Select * from aracbilgileri where AracModeli='" + txtModel.Text + "' And ModelYili='" + txtMYılıAra.Text + "' ";

                string SorguAracMarkaAracModelAracModelYili = "Select * from aracbilgileri where AracMarkasi='" + cmbMarkaAra.Text + "' And AracModeli='" + txtModel.Text + "' And ModelYili= '" + txtMYılıAra.Text + "' ";

                if (chkMarka.Checked == true && chkModel.Checked == true && chkModelYıl.Checked == true)
                    SorguTumKayitlar = SorguAracMarkaAracModelAracModelYili;

                else if (chkMarka.Checked == true && chkModel.Checked == true)
                    SorguTumKayitlar = SorguAracMarkaAracModel;
                else if (chkMarka.Checked == true && chkModelYıl.Checked == true)
                    SorguTumKayitlar = SorguAracMarkaAracModelYili;
                else if (chkModel.Checked == true && chkModelYıl.Checked == true)
                    SorguTumKayitlar = SorguAracModelAracModelYili;
                

                else if (chkMarka.Checked == true)
                    SorguTumKayitlar = SorguAracMarka;
                else if (chkModel.Checked == true)
                    SorguTumKayitlar = SorguAracModel;
                else if (chkModelYıl.Checked == true)
                    SorguTumKayitlar = SorguAracModelYili;
               


                OleDbDataAdapter da = new OleDbDataAdapter(SorguTumKayitlar, baglanti);
                da.Fill(ds, "aracbilgileri");
                dataGridView1.DataSource = ds.Tables["aracbilgileri"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Araç Kayit Arama Hata Penceresi");
            }
        }

        public void KonsiyeAracKayitAra()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguTumKayitlar = "Select * from konsiye";

                string SorguKonsiyeAracMarka = "Select * from konsiye where KonsiyeAracMarka='" + cmbKonsiyeMarka.Text + "' ";
                string SorguKonsiyeAracModel = "Select * from konsiye where KonsiyeAracModel='" + txtKonsiyeModel.Text + "' ";
                string SorguKonsiyeAracSahip = "Select * from konsiye where KonsiyeKonsiyeSahibi='" + txtKonsiyeSahip.Text + "' ";


                string SorguKonsiyeAracMarkaKonsiyeAracModel = "Select * from konsiye where KonsiyeAracMarka='" + cmbKonsiyeMarka.Text + "' And KonsiyeAracModel='" + txtKonsiyeModel.Text + "' ";
                string SorguKonsiyeAracMarkaKonsiyeAracSahip = "Select * from konsiye where KonsiyeAracMarka='" + cmbKonsiyeMarka.Text + "' And KonsiyeKonsiyeSahibi='" + txtKonsiyeSahip.Text + "' ";
                string SorguKonsiyeAracModelKonsiyeAracSahip= "Select * from konsiye where KonsiyeAracModel='" + txtKonsiyeModel.Text + "' And KonsiyeKonsiyeSahibi='" + txtKonsiyeSahip.Text + "' ";

                string SorguKonsiyeAracMarkaKonsiyeAracModelKonsiyeAracSahip = "Select * from konsiye where KonsiyeAracMarka='" + cmbKonsiyeMarka.Text + "' And KonsiyeAracModel='" + txtKonsiyeModel.Text + "' And KonsiyeKonsiyeSahibi= '" + txtKonsiyeSahip.Text + "' ";

                if (chkKonsiyeMarka.Checked == true && chkKonsiyeModel.Checked == true && chkKonsiyeSahip.Checked == true)
                    SorguTumKayitlar = SorguKonsiyeAracMarkaKonsiyeAracModelKonsiyeAracSahip;

                else if (chkKonsiyeMarka.Checked == true && chkKonsiyeModel.Checked == true)
                    SorguTumKayitlar = SorguKonsiyeAracMarkaKonsiyeAracModel;
                else if (chkKonsiyeMarka.Checked == true && chkKonsiyeSahip.Checked == true)
                    SorguTumKayitlar = SorguKonsiyeAracMarkaKonsiyeAracSahip;
                else if (chkKonsiyeModel.Checked == true && chkKonsiyeSahip.Checked == true)
                    SorguTumKayitlar = SorguKonsiyeAracModelKonsiyeAracSahip;


                else if (chkKonsiyeMarka.Checked == true)
                    SorguTumKayitlar = SorguKonsiyeAracMarka;
                else if (chkKonsiyeModel.Checked == true)
                    SorguTumKayitlar = SorguKonsiyeAracModel;
                else if (chkKonsiyeSahip.Checked == true)
                    SorguTumKayitlar = SorguKonsiyeAracSahip;



                OleDbDataAdapter da = new OleDbDataAdapter(SorguTumKayitlar, baglanti);
                da.Fill(ds, "konsiye");
                dataGridView1.DataSource = ds.Tables["konsiye"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Konsiye Araç Arama Hata Penceresi");
            }
        }




        public void PersonelHizliAra()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguTumKayitlar = "Select * from personel";

                string SorguTcnoilebaslayan = "Select * from personel where PersonelTCno like '" + txtHizliAra.Text + "%'";
                string SorguTcnoilebiten = "Select * from personel where PersonelTCno like '%" + txtHizliAra.Text + "'";
                string SorguTcnoiceren = "Select * from personel where PersonelTCno like '%" + txtHizliAra.Text + "%'";

                string SorguDogumyeriilebaslayan = "Select * from personel where PersonelDYer like '" + txtHizliAra.Text + "%'";
                string SorguDogumyeriilebiten = "Select * from personel where PersonelDYer like '%" + txtHizliAra.Text + "'";
                string SorguDogumyeriiceren = "Select * from personel where PersonelDYer like '%" + txtHizliAra.Text + "%'";

                string SorguPersonelisimilebaslayan = "Select * from personel where Personelİsim like '" + txtHizliAra.Text + "%'";
                string SorguPersonelisimilebiten = "Select * from personel where Personelİsim like '%" + txtHizliAra.Text + "'";
                string Personelisimiceren = "Select * from personel where Personelİsim like '%" + txtHizliAra.Text + "%'";

                if (radTCNo.Checked == true)
                {
                    if (cmbAramaTuru.Text == "İle Başlayan")
                        SorguTumKayitlar = SorguTcnoilebaslayan;

                    else if (cmbAramaTuru.Text == "İle Biten")
                        SorguTumKayitlar = SorguTcnoilebiten;

                    else if (cmbAramaTuru.Text == "İçeren")
                        SorguTumKayitlar = SorguTcnoiceren;
                }

                else if (radDYer.Checked == true)

                {
                    if (cmbAramaTuru.Text == "İle Başlayan")
                        SorguTumKayitlar = SorguDogumyeriilebaslayan;

                    else if (cmbAramaTuru.Text == "İle Biten")
                        SorguTumKayitlar = SorguDogumyeriilebiten;

                    else if (cmbAramaTuru.Text == "İçeren")
                        SorguTumKayitlar = SorguDogumyeriiceren;
                }


                else if (radDTar.Checked == true)

                {
                    if (cmbAramaTuru.Text == "İle Başlayan")
                        SorguTumKayitlar = SorguPersonelisimilebaslayan;

                    else if (cmbAramaTuru.Text == "İle Biten")
                        SorguTumKayitlar = SorguPersonelisimilebiten;

                    else if (cmbAramaTuru.Text == "İçeren")
                        SorguTumKayitlar = Personelisimiceren;
                }

                OleDbDataAdapter da = new OleDbDataAdapter(SorguTumKayitlar, baglanti);
                da.Fill(ds, "personel");
                dataGridView1.DataSource = ds.Tables["personel"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Hızlı Arama Hata Penceresi");
            }
        }


        public void AracStokHizliAra()
        {
            try
            {
                BaglantiAc();
                DataSet ds = new DataSet();
                string SorguTumKayitlar = "Select * from aracbilgileri";

                string SorguAracMarkasiilebaslayan = "Select * from aracbilgileri where AracMarkasi like '" + txtStokHizliAra.Text + "%'";
                string SorguAracMarkasiilebiten = "Select * from aracbilgileri where AracMarkasi like '%" + txtStokHizliAra.Text + "'";
                string SorguAracMarkasiiceren = "Select * from aracbilgileri where AracMarkasi like '%" + txtStokHizliAra.Text + "%'";

                string SorguAracModeliilebaslayan = "Select * from aracbilgileri where AracModeli like '" + txtStokHizliAra.Text + "%'";
                string SorguAracModeliilebiten = "Select * from aracbilgileri where AracModeli like '%" + txtStokHizliAra.Text + "'";
                string SorguAracModeliiceren = "Select * from aracbilgileri where AracModeli like '%" + txtStokHizliAra.Text + "%'";

                string SorguAracModelYiliilebaslayan = "Select * from aracbilgileri where ModelYili like '" + txtStokHizliAra.Text + "%'";
                string SorguAracModelYiliilebiten = "Select * from aracbilgileri where ModelYili like '%" + txtStokHizliAra.Text + "'";
                string AracModelYiliiceren = "Select * from aracbilgileri where ModelYili like '%" + txtStokHizliAra.Text + "%'";

                if (radAracMarka.Checked == true)
                {
                    if (cmbAramaTuru.Text == "İle Başlayan")
                        SorguTumKayitlar = SorguAracMarkasiilebaslayan;

                    else if (cmbAramaTuru.Text == "İle Biten")
                        SorguTumKayitlar = SorguAracMarkasiilebiten;

                    else if (cmbAramaTuru.Text == "İçeren")
                        SorguTumKayitlar = SorguAracMarkasiiceren;
                }

                else if (radAracModel.Checked == true)

                {
                    if (cmbAramaTuru.Text == "İle Başlayan")
                        SorguTumKayitlar = SorguAracModeliilebaslayan;

                    else if (cmbAramaTuru.Text == "İle Biten")
                        SorguTumKayitlar = SorguAracModeliilebiten;

                    else if (cmbAramaTuru.Text == "İçeren")
                        SorguTumKayitlar = SorguAracModeliiceren;
                }


                else if (radAracModelYili.Checked == true)

                {
                    if (cmbAramaTuru.Text == "İle Başlayan")
                        SorguTumKayitlar = SorguAracModelYiliilebaslayan;

                    else if (cmbAramaTuru.Text == "İle Biten")
                        SorguTumKayitlar = SorguAracModelYiliilebiten;

                    else if (cmbAramaTuru.Text == "İçeren")
                        SorguTumKayitlar = AracModelYiliiceren;
                }

                OleDbDataAdapter da = new OleDbDataAdapter(SorguTumKayitlar, baglanti);
                da.Fill(ds, "aracbilgileri");
                dataGridView1.DataSource = ds.Tables["aracbilgileri"];
                baglanti.Close();
            }
            catch (Exception Hata)
            {

                MessageBox.Show(Hata.Message, "Araç Stok Hızlı Arama Hata Penceresi");
            }
        }


        private void opsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void opsyonlananAraçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çekSenetÖdemeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sistemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void personelBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelListele();
        }

        private void araçBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AracListele();
        }

        private void araçAlımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AracAlisListele();
        }

        private void araçSatışGelirleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GelirListele();
        }

        private void taksitÖdemeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaksitÖdemeleriListele();
        }

        private void araçGiderleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiderListele();
        }

        private void personelGiderleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelGiderListele();
        }

        private void dükkanGiderleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DukkanGiderListele();
        }

        private void sigortaÖdemeleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void personelÖdemeBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelÖdemeListele();
        }

        private void personelMaaşBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelMaasListele();
        }

        private void araçSigortaBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SigortaGiderListele();
        }

        private void araçSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AracSatisListele();
        }

        private void konsiyeAraçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KonsiyeListele();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void araçSatışEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();


        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            baglanti.Close();
            PersonelListele();
            AracListele();


        }

        private void araçAlışSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaracalissil frmSil = new frmaracalissil();
            frmSil.ShowDialog();
        }

        private void araçSatışSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaracsatissil frmASil =new frmaracsatissil();
            frmASil.ShowDialog();

        }

        private void araçStokEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaracstokekle frmEkle = new frmaracstokekle();
            frmEkle.ShowDialog();
        }

        private void konsiyeAraçEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmkonsiyearacekle frmKoEkle = new frmkonsiyearacekle();
            frmKoEkle.ShowDialog();
        }

        private void toolStripSplitButton7_ButtonClick(object sender, EventArgs e)
        {
            
        }

        private void personelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpersonelekle frmPEkle = new frmpersonelekle();
            frmPEkle.ShowDialog();
        }

        private void araçStokSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaracstoksil frmAsSil= new frmaracstoksil();
            frmAsSil.ShowDialog();
        }

        private void konsiyeAraçSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmkonsiyearacsil frmKsil = new frmkonsiyearacsil();
            frmKsil.ShowDialog();
        }

        private void frmAnaSayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            {
                DialogResult cevap;

                cevap = MessageBox.Show("Programdan Çıkmak İstiyor Musunuz?", "Çıkış", MessageBoxButtons.YesNo);

                if (cevap == DialogResult.Yes)
                {

                    Application.Exit();
                }
                else
                    MessageBox.Show("Programa Geri Dönülüyor!");
            }
        }

        private void araçAlımEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaracalim frmAAEkle = new frmaracalim();
            frmAAEkle.ShowDialog();
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void araçSatışGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaracstisguncelle frmASGuncelle = new frmaracstisguncelle();
            frmASGuncelle.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void araçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void özelleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBirimTanimlama frm = new frmBirimTanimlama();
            frm.ShowDialog();
        }

        private void personelİsimTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonelİsimTanımlama frm = new frmPersonelİsimTanımlama();
            frm.ShowDialog();
        }

        private void araçMarkaTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAracMarkaTanımlama frm = new frmAracMarkaTanımlama();
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chkAd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAd.Checked == true)
            {
                txtAdAra.Enabled = true;
                txtAdAra.Focus();

            }
            else
            {
                txtAdAra.Enabled = false;
                txtAdAra.Text = "";
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            PersonelKayitAra();
        }

        private void chkSoyad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoyad.Checked == true)
            {
                txtTcNoAra.Enabled = true;
                txtTcNoAra.Focus();

            }
            else
            {
                txtTcNoAra.Enabled = false;
                txtTcNoAra.Text = "";
            }
        }

        private void chkBirim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBirim.Checked == true)
            {
                cmbBirimAra.Enabled = true;
                cmbBirimAra.Focus();
            }
            else
                cmbBirimAra.Enabled = false;
            cmbBirimAra.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (chkSoyad.Checked == true)
            {
                txtTlfNoAra.Enabled = true;
                txtTlfNoAra.Focus();

            }
            else
            {
                txtTlfNoAra.Enabled = false;
                txtTlfNoAra.Text = "";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void araçAlışGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void araçStokGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void opsiyonlananArçToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radTCNo_CheckedChanged(object sender, EventArgs e)
        {
            lblArananAlan.Text = "TC No";
            txtHizliAra.Focus();
            txtHizliAra.Text = "";
        }

        private void radDYer_CheckedChanged(object sender, EventArgs e)
        {
            lblArananAlan.Text = "TC No";
            txtHizliAra.Focus();
            txtHizliAra.Text = "";
        }

        private void radDTar_CheckedChanged(object sender, EventArgs e)
        {
            lblArananAlan.Text = "Personel İsim";
            txtHizliAra.Focus();
            txtHizliAra.Text = "";
        }

        private void txtHizliAra_TextChanged(object sender, EventArgs e)
        {
            PersonelHizliAra();
        }

        private void chkKonsiyeMarka_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMarka.Checked == true)
            {
                cmbMarkaAra.Enabled = true;
                cmbMarkaAra.Focus();

            }
            else
            {
                cmbMarkaAra.Enabled = false;
                cmbMarkaAra.Text = "";
            }
        }

        private void chkModel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModel.Checked == true)
            {
                txtModel.Enabled = true;
                txtModel.Focus();

            }
            else
            {
                txtModel.Enabled = false;
                txtModel.Text = "";
            }
        }

        private void chkModelYıl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModelYıl.Checked == true)
            {
                txtMYılıAra.Enabled = true;
                txtMYılıAra.Focus();

            }
            else
            {
                txtMYılıAra.Enabled = false;
                txtMYılıAra.Text = "";
            }
        }



        private void btnAracAra_Click(object sender, EventArgs e)
        {
            AracKayitAra();
        }        

        private void txtKonsiyeSahip_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbMarkaAra_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KonsiyeAracKayitAra();
        }

        private void chkKonsiyeMarka_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkKonsiyeMarka.Checked == true)
            {
                cmbKonsiyeMarka.Enabled = true;
                cmbKonsiyeMarka.Focus();

            }
            else
            {
                cmbKonsiyeMarka.Enabled = false;
                cmbKonsiyeMarka.Text = "";
            }
        }

        private void chkKonsiyeModel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKonsiyeModel.Checked == true)
            {
                txtKonsiyeModel.Enabled = true;
                txtKonsiyeModel.Focus();

            }
            else
            {
                txtKonsiyeModel.Enabled = false;
                txtKonsiyeModel.Text = "";
            }
        }

        private void chkKonsiyeSahip_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKonsiyeSahip.Checked == true)
            {
                txtKonsiyeSahip.Enabled = true;
                txtKonsiyeSahip.Focus();

            }
            else
            {
                txtKonsiyeSahip.Enabled = false;
                txtKonsiyeSahip.Text = "";
            }
        }

        private void txtStokHizliAra_TextChanged(object sender, EventArgs e)
        {
            AracStokHizliAra();
        }

        private void lblArananAlanStok_Click(object sender, EventArgs e)
        {

        }

        private void lblArananAlanStok_Click_1(object sender, EventArgs e)
        {

        }

        private void radaracMarka_CheckedChanged(object sender, EventArgs e)
        {

            lblArananAlanStok.Text = "Araç Markası";
            txtStokHizliAra.Focus();
            txtStokHizliAra.Text = "";
        }

        private void radAracModel_CheckedChanged(object sender, EventArgs e)
        {
            lblArananAlanStok.Text = "Araç Model";
            txtStokHizliAra.Focus();
            txtStokHizliAra.Text = "";
        }

        private void radAracModelYili_CheckedChanged(object sender, EventArgs e)
        {
            lblArananAlanStok.Text = "Araç model Yılı";
            txtStokHizliAra.Focus();
            txtStokHizliAra.Text = "";
        }

        private void giderKalemleriTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGiderlerTanımlama frm = new frmGiderlerTanımlama();
            frm.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFinalUygulama frmRapor1 = new frmFinalUygulama();
            frmRapor1.ShowDialog();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void personelMaaşTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonelMaasTanımlama frmRapor1 = new frmPersonelMaasTanımlama();
            frmRapor1.ShowDialog();
        }

        private void personelBankaBilgileriTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonelÖdemeBilgileri frmBanka = new frmPersonelÖdemeBilgileri();
            frmBanka.ShowDialog();
        }

        private void txtTcNoAra_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            lisans frmlisans = new lisans();
            frmlisans.ShowDialog();
        }
    }
}
