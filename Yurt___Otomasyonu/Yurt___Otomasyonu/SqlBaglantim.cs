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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Yurt___Otomasyonu
{
    class SqlBaglantim
    {
        public SqlConnection baglanti() //Diğer formlarda nesne aracıyla çağıra bilmek için metod oluşturduk Data Source=DESKTOP-F2NBRET\SQLEXPRESS01;Initial Catalog=YurtKayit;Integrated Security=True
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-F2NBRET\SQLEXPRESS01;Initial Catalog=YurtKayit;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
