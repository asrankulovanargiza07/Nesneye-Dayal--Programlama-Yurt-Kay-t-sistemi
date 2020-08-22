/********************************************************************************************
 * *                                SAKARYA ÜNİVERSİTESİ
 * *                        BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
 * *                            BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
 * *                               NESNEYE DAYALI PROGRAMLAMA DERSİ
 * *                                      2019-2020 YAZ DÖNEMİ
 * 
 * *                        PROJE NUMARASI..........: 01
 * *                        ÖĞRENCİ ADI.............: NARGİZA ASRANKULOVA
 * *                        ÖĞRENCİ NUMARASI........:s191200015
 * *                        DERSİN ALDIĞI GRUP......:A 
 ****************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Yurt___Otomasyonu
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayıtDataSet1.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.yurtKayıtDataSet1.Ogrenci);
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MsPaint.Exe");
        }

        private void radyo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://powerfm.listenpowerapp.com/powerfm/abr/playlist.m3u8";//Power Fm
        }

        private void radyo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://icast.powergroup.com.tr/PowerTurk/mpeg/128/home";
           // axWindowsMediaPlayer1.URL = "http://icast.powergroup.com.tr/PowerTurk/mpeg/128/home";//Power Türk
        }

        private void radyo3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://provisioning.streamtheworld.com/pls/METRO_FMAAC.pls";//Metro Fm
        }

        private void kastamonu105FMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://www.dostmedya.com/ply/1001fm.pls";
        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrKayit fr = new FrmOgrKayit();
            fr.Show();
        }

        private void öğrenciListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrListele fr = new FrmOgrListele();
            fr.Show();
        }

        private void öğrenciDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrListele fr = new FrmOgrListele();
            fr.Show();
        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        private void bölümDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOdemeler fr = new FrmOdemeler();
            fr.Show();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGider fr = new FrmGider();
            fr.Show();
        }

        private void giderListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderListesi fr = new FrmGiderListesi();
            fr.Show();
        }

        private void gelirİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGelirIstatistik fr = new FrmGelirIstatistik();
            fr.Show();
        }

        private void giderİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderListesi fr = new FrmGiderListesi();
            fr.Show();
        }

        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmYoneticiDuzenle fr= new FrmYoneticiDuzenle();
            fr.Show();

        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonel fr = new FrmPersonel();
            fr.Show();
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotEkle fr = new FrmNotEkle();
            fr.Show();
        }

        private void öğrenciBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrenciRapor fr = new FrmOgrenciRapor();
            fr.Show();
        }

        private void hakkımmızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program Nargiza Asrankulova Tarafından 17 Haziran 2019 da tamamlanmıştır.","Öğrenci Yurt Otomasyon",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Çıkmak istediğinizden emin misiniz?","Çıkış", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAnaForm fr = new FrmAnaForm();
            fr.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ogrenciTableAdapter.Fill(this.yurtKayıtDataSet1.Ogrenci);
        }

        private void TxtAd_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Ogrenci where OgrAd like '%" + TxtAd.Text + "%'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.baglanti().Close();
        }

        private void TxtSoyad_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Ogrenci where OgrSoyad like '%" + TxtSoyad.Text + "%'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.baglanti().Close();
        }

        private void TxtTC_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Ogrenci where OgrOdaNo like '%" + TxtOdaNo.Text + "%'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.baglanti().Close();
        }
    }
}

