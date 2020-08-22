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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayıtDataSet6.Personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.yurtKayıtDataSet6.Personel);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Personel(PersonelAdSoyad,PersonelDepartman) values(@p1,@p2)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtPersonelAd.Text);
            komut.Parameters.AddWithValue("@p2",TxtPersonelGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Eklendi");
            this.personelTableAdapter.Fill(this.yurtKayıtDataSet6.Personel);

            TxtPersonelid.Text = "";
            TxtPersonelAd.Text = "";
            TxtPersonelGorev.Text = "";

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Personel Where Personelid=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtPersonelid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silindi");
            this.personelTableAdapter.Fill(this.yurtKayıtDataSet6.Personel);

            TxtPersonelid.Text = "";
            TxtPersonelAd.Text = "";
            TxtPersonelGorev.Text = "";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, gorev, id;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            gorev = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

           
            TxtPersonelid.Text = id;
            TxtPersonelAd.Text = ad;
            TxtPersonelGorev.Text = gorev;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutgun = new SqlCommand("update Personel set PersonelAdSoyad=@p1,PersonelDepartman=@p2 where Personelid=@p3",bgl.baglanti());
            komutgun.Parameters.AddWithValue("@p1",TxtPersonelAd.Text);
            komutgun.Parameters.AddWithValue("@p2",TxtPersonelGorev.Text);
            komutgun.Parameters.AddWithValue("@p3",TxtPersonelid.Text);
            komutgun.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");
            this.personelTableAdapter.Fill(this.yurtKayıtDataSet6.Personel);

            TxtPersonelid.Text = "";
            TxtPersonelAd.Text = "";
            TxtPersonelGorev.Text = "";



        }
    }
}
