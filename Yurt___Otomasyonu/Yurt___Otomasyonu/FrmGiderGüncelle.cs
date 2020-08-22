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
    public partial class FrmGiderGüncelle : Form
    {
        public FrmGiderGüncelle()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        public string elektrik, su, dogalgaz, gida, diger, internet, personel,id;
        private void FrmGiderGüncelle_Load(object sender, EventArgs e)
        {
            TxtGiderid.Text = id;
            TxtElektrik.Text = elektrik;
            TxtGida.Text = gida;
            TxtSu.Text = su;
            TxtPersonel.Text = personel;
            TxtInternet.Text = internet;
            TxtDogalgaz.Text = dogalgaz;
            TxtDiger.Text = diger;


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            try
            {
                 SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p1,Su=@p2,Dogalgaz=@p3,internet=@p4,Gıda=@p5,Personel=@p6,Diger=@p7 where Odemeid=@p8", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtElektrik.Text);
            komut.Parameters.AddWithValue("@p2", TxtSu.Text);
            komut.Parameters.AddWithValue("@p3", TxtDogalgaz.Text);
            komut.Parameters.AddWithValue("@p4", TxtInternet.Text);
            komut.Parameters.AddWithValue("@p5", TxtGida.Text);
            komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
            komut.Parameters.AddWithValue("@p7", TxtDiger.Text);
            komut.Parameters.AddWithValue("@p8",TxtGiderid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncellendi");
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!! GÜNCELLENMEDİ! Yeniden deneyin.");
            }
        }
    }
}
