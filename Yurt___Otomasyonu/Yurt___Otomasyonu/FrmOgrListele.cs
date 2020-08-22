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
    public partial class FrmOgrListele : Form
    {
        public FrmOgrListele()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmOgrListele_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayıtDataSet3.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.yurtKayıtDataSet3.Ogrenci);

        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //secilen id yi duzenle formuna aktarma kodu
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            FrmOgrDuzenle fr = new FrmOgrDuzenle();
            fr.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            fr.ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            fr.soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            fr.TC = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            fr.telefon = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            fr.dogum = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            fr.bolum = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            fr.mail = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            fr.odano = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            fr.veliad = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            fr.velitel = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            fr.adres = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            
            fr.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Ogrenci where OgrSoyad like '%" + TxtSoyad.Text + "%'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.baglanti().Close();

        }

        private void TxtAd_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Ogrenci where OgrAd like '%"+TxtAd.Text+"%'",bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.baglanti().Close();

        }

        private void TxtTC_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Ogrenci where OgrTC like '%" + TxtTC.Text + "%'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.baglanti().Close();

        }

        private void TxtTelefon_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Ogrenci where OgrTelefon like '%" + TxtTelefon.Text + "%'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bgl.baglanti().Close();

        }
    }
}
