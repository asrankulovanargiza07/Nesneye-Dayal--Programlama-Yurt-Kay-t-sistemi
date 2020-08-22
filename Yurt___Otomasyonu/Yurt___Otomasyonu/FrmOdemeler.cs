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
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayıtDataSet2.Borclar' table. You can move, or remove it, as needed.
            this.borclarTableAdapter.Fill(this.yurtKayıtDataSet2.Borclar);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, soyad, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();  
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtAd.Text = ad;
            TxtSoyad.Text = soyad;
            TxtKalan.Text = kalan;
            TxtOgrid.Text = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TxtOgrid.Text!=""||TxtAd.Text!=""||TxtSoyad.Text!=""||TxtOdenen.Text!=""||TxtKalan.Text!=""||CmbOdenenAy.Text!="")
            {
                //ödenen tutarı kalan tutardan düşme
                int odenen, kalan, yeniborc;
                odenen = Convert.ToInt16(TxtOdenen.Text);
                kalan = Convert.ToInt16(TxtKalan.Text);
                yeniborc = kalan - odenen;
                TxtKalan.Text = yeniborc.ToString();

                //Yeni tutarı Veri tabana kaydetme
                SqlCommand komut = new SqlCommand("update Borclar set OgrKalanBorc=@p1 where Ogrid=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p2", TxtOgrid.Text);
                komut.Parameters.AddWithValue("@p1", TxtKalan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Borç Ödendi");
                this.borclarTableAdapter.Fill(this.yurtKayıtDataSet2.Borclar);

                //Kasa tablosuna ekleme yapma
                //SqlCommand komut2 = new SqlCommand("update Kasa set OdemeAy=@k1,OdemeMiktar=@k2 where Ogrenci.Ogrid=@k3",bgl.baglanti());
                SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy,OdemeMiktar) values (@k1,@k2)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@k1", CmbOdenenAy.Text);
                komut2.Parameters.AddWithValue("@k2", TxtOdenen.Text);
                //  komut2.Parameters.AddWithValue("@k3",TxtOgrid.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                TxtOgrid.Text="";
                TxtAd.Text="";
                TxtSoyad.Text="";
                TxtOdenen.Text="";
                TxtKalan.Text="";
                CmbOdenenAy.Text="";
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız");
            }
            

        }
    }
}
