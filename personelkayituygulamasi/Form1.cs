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


namespace personelkayituygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=**;Initial Catalog=PersonelVeriTabani;Integrated Security=True;TrustServerCertificate=True");

        public void temizle()
        {
            TxtPersonelAd.Text = "";
            TxtPersonelSoyad.Text = "";
            TxtPersonelID.Text = "";
            TxtPersonelMeslek.Text = "";
            TxtPersonelSehir.Text = "";
            TxtPersonelMaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtPersonelAd.Focus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet1.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPersonelMeslek_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Tbl_Personel(PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            cmd.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtPersonelSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", TxtPersonelSehir.Text);
            cmd.Parameters.AddWithValue("@p4", TxtPersonelMaas.Text);
            cmd.Parameters.AddWithValue("@p5", TxtPersonelMeslek.Text);
            cmd.Parameters.AddWithValue("@p6", label8.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked== true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtPersonelID.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtPersonelAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtPersonelSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtPersonelSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtPersonelMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtPersonelMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }

            if (label8.Text == "False")
            {

                radioButton2.Checked = true;
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", TxtPersonelID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where Perid=@a7",baglanti);
            komutguncelle.Parameters.AddWithValue("@a1",TxtPersonelAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", TxtPersonelSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", TxtPersonelSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", TxtPersonelMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", TxtPersonelMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7",TxtPersonelID.Text);
            komutguncelle .ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Güncellendi");
        }

        private void Btnİstatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            grafikler frg = new grafikler();
            frg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
