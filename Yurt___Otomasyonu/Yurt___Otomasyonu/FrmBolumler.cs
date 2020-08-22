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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }

         SqlBaglantim bgl = new SqlBaglantim();
        private void FrmBolunler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayıtDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtKayıtDataSet.Bolumler);

        }

        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {
            try
            {
            SqlCommand komut1 = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",TxtBolumAd.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bölüm Eklendi");
            this.bolumlerTableAdapter.Fill(this.yurtKayıtDataSet.Bolumler);//Refresh yapıyor
            }
            catch 
            {
                MessageBox.Show("Hata Oluştu Yeniden Deneyin");

            }

        }

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {
               SqlCommand komut2 = new SqlCommand("delete from Bolumler where Bolumid=@p1",bgl.baglanti());
               komut2.Parameters.AddWithValue("@p1", TxtBolumid.Text);
               komut2.ExecuteNonQuery();
               bgl.baglanti().Close();
               MessageBox.Show("Silme İşlemi Gerçekleşti");
               this.bolumlerTableAdapter.Fill(this.yurtKayıtDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("HATA! Silme İşlemi Gerçekleşmedi!");
            }
        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;//seçilmiş olan satırın indexini aktardım
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString(); //Satırlarda seçilen satırın id'sini string olarak aktaracak (0.(столб)hücre idleri listeliyor)
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();//1.стоб это Bolum Adı

            TxtBolumid.Text = id;
            TxtBolumAd.Text = bolumad;
        }

        private void PcbBolumDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut3 = new SqlCommand("update Bolumler Set Bolumad =@p1 where Bolumid =@p2", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p2",TxtBolumid.Text);
                komut3.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncellenme İşlemi Gerçekleşti");
                this.bolumlerTableAdapter.Fill(this.yurtKayıtDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!! Güncellenme İşlemi Gerçekleştirilmedi!!");
            }
        }

        private void PcbBolumEkle_MouseEnter(object sender, EventArgs e)
        {
            PcbBolumEkle.Height += 10;
            PcbBolumEkle.Width += 10;
        }

        private void PcbBolumEkle_MouseLeave(object sender, EventArgs e)
        {
            PcbBolumEkle.Width -= 10;
            PcbBolumEkle.Height -= 10;
        }

        private void PcbBolumSil_MouseEnter(object sender, EventArgs e)
        {
            PcbBolumSil.Width += 10;
            PcbBolumSil.Height += 10;
        }

        private void PcbBolumSil_MouseLeave(object sender, EventArgs e)
        {
            PcbBolumSil.Width -= 10;
            PcbBolumSil.Height -= 10;
        }

        private void PcbBolumDuzenle_MouseEnter(object sender, EventArgs e)
        {
            PcbBolumDuzenle.Width += 10;
            PcbBolumDuzenle.Height += 10;
        }

        private void PcbBolumDuzenle_MouseLeave(object sender, EventArgs e)
        {
            PcbBolumDuzenle.Width -= 10;
            PcbBolumDuzenle.Height -= 10;
        }
    }
}
