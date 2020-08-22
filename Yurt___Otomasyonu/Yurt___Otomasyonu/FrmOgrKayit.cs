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
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        bool durum;

        void tekrar()
        {
            //bgl.baglanti();
            SqlCommand komut = new SqlCommand("Select * from Ogrenci where OgrTC =@prm1",bgl.baglanti());
            komut.Parameters.AddWithValue("@prm1",MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            TxtOgrAd.Clear();
            TxtOgrSoyad.Clear();
            MskTC.Clear();
            MskOgrTelefon.Clear();
            MskDogum.Clear();
            CmbBolum.Text = "";
            TxtMail.Clear();
            CmbOdaNo.Text = "";
            TxtVeliAdSoyad.Clear();
            MskVeliTelefon.Clear();
            RchAdres.Clear();
        }

        private void FrmOgrKayit_Load(object sender, EventArgs e)
        {
            //Bölümleri Listeleme Komutları

            SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();

            //Boş Odaları Listeleme Komutları

            SqlCommand komut2 = new SqlCommand("Select Odano From Odalar where OdaKapasite != OdaAktif", bgl.baglanti());
            //komut2.Connection = bgl.baglanti();
            //komut2.CommandText = ("Select Odano From Odalar where OdaKapasite != OdaAktif");
            //SqlCommand komut2 = new SqlCommand("Select Odano From Odalar");
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(MskTC.TextLength!=11||MskOgrTelefon.TextLength<11)
            {
                MessageBox.Show("TC veya Telefon Eksik Girildi");
            }
            else
            {
                tekrar();
                if(durum==true)
                {
                      try
                      {
            
                
                    SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci(OgrAd,OgrSoyad,OgrTC,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                    komutkaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text);
                    komutkaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
                    komutkaydet.Parameters.AddWithValue("@p3", MskTC.Text);
                    komutkaydet.Parameters.AddWithValue("@p4", MskOgrTelefon.Text);
                    komutkaydet.Parameters.AddWithValue("@p5", MskDogum.Text);
                    komutkaydet.Parameters.AddWithValue("@p6", CmbBolum.Text);
                    komutkaydet.Parameters.AddWithValue("@p7", TxtMail.Text);
                    komutkaydet.Parameters.AddWithValue("@p8", CmbOdaNo.Text);
                    komutkaydet.Parameters.AddWithValue("@p9", TxtVeliAdSoyad.Text);
                    komutkaydet.Parameters.AddWithValue("@p10", MskVeliTelefon.Text);
                    komutkaydet.Parameters.AddWithValue("@p11", RchAdres.Text);
                    komutkaydet.ExecuteNonQuery();//Sorgular üzerinde değişiklikleri gerçekleştiriyor
                    bgl.baglanti().Close();
                    MessageBox.Show("Kayıt Başarılı Bir Şekilde Eklendi");
                    temizle();
                    //Öğrenci id yi Labele çekme
                    SqlCommand komut = new SqlCommand("select Ogrid from Ogrenci", bgl.baglanti());
                    SqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        label12.Text = oku[0].ToString();

                    }
                    oku.Close();
                    bgl.baglanti().Close();


                    //Öğrenci Borç Alanı Oluşturma
                    SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar (Ogrid,OgrAd,OgrSoyad) values(@b1,@b2,@b3)", bgl.baglanti());
                    komutkaydet2.Parameters.AddWithValue("@b1", label12.Text);
                    komutkaydet2.Parameters.AddWithValue("@b2", TxtOgrAd.Text);
                    komutkaydet2.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text);
                    komutkaydet2.ExecuteNonQuery();
                    bgl.baglanti().Close();


                      }
                      catch (Exception)
                      {

                          MessageBox.Show("Hata Kaydedilemedi");
                      }
                }
                else
                {
                    MessageBox.Show("Aynı TC 1 den fazla kez kaydedilemez");

                }

                
                }
            //Aynı TCT  engeli
            //DataTable tb1 = new DataTable();
            //using(var con=bgl.baglanti())
            //{
            //    var cmd = new SqlCommand(@"insert into Ogrenci (OgrTC,Ogrid) select where not exists (select * from Ogrenci where OgrTC =@tcNo); select * from Ogrenci where OgrTC=@tcNo",bgl.baglanti());

            //    cmd.Parameters.AddWithValue("@tcNo",MskTC.Text);
            // //   cmd.Parameters.AddWithValue("@diger",);
            //}

            //Öğrenci bilgileri kayıt edilme komutları
          
                //}
                //else
                //{
                //    MessageBox.Show("TC aynı olamaz");
                //}
                //okuyucu.Close();

               
            //Öğrenci Oda Kontenjanını Arttırma

            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo =@oda1",bgl.baglanti());
            komutoda.Parameters.AddWithValue("@oda1",CmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();


        }

        private void TxtOgrAd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void TxtOgrSoyad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void MskTC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void MskOgrTelefon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void MskDogum_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void MskDogum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void CmbBolum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void TxtMail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void CmbOdaNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void TxtVeliAdSoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtVeliAdSoyad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void MskVeliTelefon_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void RchAdres_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void BtnKaydet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(sender as Control, true, true, true, true);
        }

        private void CmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbOdaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(CmbOdaNo.Text);
        }

        //private void TxtOgrSoyad_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}

//Data Source=DESKTOP-F2NBRET\SQLEXPRESS;Initial Catalog=YurtKayıt;Integrated Security=True