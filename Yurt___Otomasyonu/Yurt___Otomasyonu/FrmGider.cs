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
    public partial class FrmGider : Form
    {
        public FrmGider()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmGider_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 SqlCommand komut = new SqlCommand("insert into Giderler(Elektrik,Su,Dogalgaz, internet,Gıda,Personel,Diger) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtElektrik.Text);
            komut.Parameters.AddWithValue("@p2",TxtSu.Text);
            komut.Parameters.AddWithValue("@p3", TxtDogalgaz.Text);
            komut.Parameters.AddWithValue("@p4", TxtInternet.Text);
            komut.Parameters.AddWithValue("@p5", TxtGida.Text);
            komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
            komut.Parameters.AddWithValue("@p7", TxtDiger.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıtlar Eklendi");

            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void TxtDiger_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void TxtPersonel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TxtGida_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TxtInternet_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TxtDogalgaz_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtSu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TxtElektrik_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
