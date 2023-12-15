using BMU3311_VeriYonetimi;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static BMU3311_VeriYonetimi.Student_Class;

namespace BMÜ3311_OgrenciOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            for (int sayac = 0; sayac < 10000; sayac++)
            {
                Students.Add(Student_Class.CreateRandomStudent());
            }

            // Öğrenciler eklenip liste dolu olduktan sonra sıralama yapılmalı
            Student_Class.BolumSirala();
            Student_Class.SiniflariSırala();

            for (int sayac = 0; sayac < 10000; sayac++)
            {
                OgrenciList.Rows.Add(Students[sayac].No, Students[sayac].İsim, Students[sayac].Soyad, Students[sayac].Gano, 
                    Students[sayac].BolumSira, Students[sayac].SınıfSira, Students[sayac].Sınıf, Students[sayac].Cinsiyet);
            }
            btnOlustur.Enabled = false;
            btnList.Enabled = true;
            btnAra.Enabled = true;
            btnSırala.Enabled = true;
            btnRaporOlustur.Enabled = true;
            comboBoxSırala.SelectedIndex = 0;
        }

        private void btnSırala_Click(object sender, EventArgs e)
        {
            string? secim = comboBoxSırala.SelectedItem.ToString();
            List<Student_Class.Student> StudentsSelect = new List<Student_Class.Student>();
            switch (secim)
            {
                case "Öğrenci Noya göre":
                    StudentsSelect = Students.OrderBy(o => o.No).ToList();
                    break;
                case "Bölüm Sırasına göre":
                    StudentsSelect = Students.OrderBy(o => o.BolumSira).ToList();
                    break;
                case "Sınıf Sırasına göre":
                    StudentsSelect = Students.OrderBy(o => o.SınıfSira).ToList();
                    break;
                case "Gano Sırasına göre":
                    StudentsSelect = Students.OrderBy(o => o.Gano).ToList();
                    break;
                case "Sadece Erkekleri":
                    StudentsSelect = Students.Where(o => o.Cinsiyet == "Erkek").ToList();
                    break;
                case "Sadece Kızları":
                    StudentsSelect = Students.Where(o => o.Cinsiyet == "Kız").ToList();
                    break;
                case "1. Sınıf":
                    StudentsSelect = Students.Where(o => o.Sınıf == 1).ToList();
                    break;
                case "2. Sınıf":
                    StudentsSelect = Students.Where(o => o.Sınıf == 2).ToList();
                    break;
                case "3. Sınıf":
                    StudentsSelect = Students.Where(o => o.Sınıf == 3).ToList();
                    break;
                case "4. Sınıf":
                    StudentsSelect = Students.Where(o => o.Sınıf == 4).ToList();
                    break;
            }

            OgrenciList.Rows.Clear();
            for (int sayac = 0; sayac < StudentsSelect.Count; sayac++)
            {
                OgrenciList.Rows.Add(StudentsSelect[sayac].No, StudentsSelect[sayac].İsim, StudentsSelect[sayac].Soyad, StudentsSelect[sayac].Gano, StudentsSelect[sayac].BolumSira, StudentsSelect[sayac].SınıfSira, StudentsSelect[sayac].Sınıf, StudentsSelect[sayac].Cinsiyet);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string arama = txtAra.Text;
            List<Student> filteredStudents = Students.Where(o =>
                o.Cinsiyet.Contains(arama) ||
                o.İsim.Contains(arama) ||
                o.Soyad.Contains(arama) ||
                o.No.ToString().Contains(arama) ||
                o.Gano.ToString().Contains(arama) ||
                o.BolumSira.ToString().Contains(arama) ||
                o.SınıfSira.ToString().Contains(arama) ||
                o.Sınıf.ToString().Contains(arama)).ToList();

            OgrenciList.Rows.Clear();
            for (int sayac = 0; sayac < filteredStudents.Count; sayac++)
            {
                OgrenciList.Rows.Add(filteredStudents[sayac].No, filteredStudents[sayac].İsim, filteredStudents[sayac].Soyad, 
                    filteredStudents[sayac].Gano, filteredStudents[sayac].BolumSira, filteredStudents[sayac].SınıfSira, 
                    filteredStudents[sayac].Sınıf, filteredStudents[sayac].Cinsiyet);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save a CSV File";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                string dosyayolu = saveFileDialog.FileName;
                FileStream fs = new FileStream(dosyayolu, FileMode.Create);
                fs.Close();
                FileStream fsveri = new FileStream(dosyayolu, FileMode.Open, FileAccess.Write);
                StreamWriter swveri = new StreamWriter(fsveri);
                for (int i = 0; i < Students.Count; i++)
                {
                    string veri = OgrenciList.Rows[i].Cells[0].Value.ToString() + ";" + OgrenciList.Rows[i].Cells[1].Value + ";" + 
                        OgrenciList.Rows[i].Cells[2].Value + ";" + OgrenciList.Rows[i].Cells[3].Value.ToString() + ";" + 
                        OgrenciList.Rows[i].Cells[4].Value.ToString() + ";" + OgrenciList.Rows[i].Cells[5].Value.ToString() + ";" + 
                        OgrenciList.Rows[i].Cells[6].Value.ToString() + ";" + OgrenciList.Rows[i].Cells[7].Value;
                    swveri.WriteLine(veri);
                }
                swveri.Close();
                fsveri.Close();
                MessageBox.Show(" Öğrenciler .csv dosya uzantısı ile " + dosyayolu + " konumuna kaydedildi.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRaporOlustur_Click(object sender, EventArgs e)
        {
            Raporla();
        }
        private void Raporla()
        {
            if (OgrenciList == null || OgrenciList.Rows.Count == 0)
            {
                MessageBox.Show("Öğrenci listesi boş veya null. Lütfen önce öğrenci oluşturun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Save a CSV File";

                // Kullanıcıya dosya kaydetme konumu seçtir
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Seçilen dosya yolunu al
                    string dosyaYolu = saveFileDialog.FileName;

                    // Dosyayı oluştur
                    using (StreamWriter sw = new StreamWriter(dosyaYolu, false, Encoding.UTF8))
                    {
                        // Öğrenci sayısı
                        int ogrenciSayisi = (OgrenciList.Rows.Count - 1);
                        sw.WriteLine($"Toplam Öğrenci Sayısı: {ogrenciSayisi}");

                        // Sınıf dizisi oluşturuluyor ve tüm sınıflar DataGridView'den alınıyor.
                        var siniflar = OgrenciList.Rows.Cast<DataGridViewRow>().Select(r => r.Cells["Sınıf"].Value?.ToString()).Distinct().ToList();

                        // Her bir sınıfın yüzdesini hesapla ve rapora ekle
                        foreach (var sinif in siniflar)
                        {
                            double sinifYuzde = (double)OgrenciList.Rows.Cast<DataGridViewRow>().Count(r => r.Cells["Sınıf"].Value?.ToString() == sinif) / (double)ogrenciSayisi * 100;
                            sw.WriteLine($"Sınıf {sinif} Yüzdesi: %{sinifYuzde:F2}");
                        }


                        // En çok olan soyadı
                        string enCokOlanSoyad = OgrenciList.Rows.Cast<DataGridViewRow>()
                            .GroupBy(r => r.Cells["Soyad"].Value?.ToString())
                            .OrderByDescending(g => g.Count())
                            .First()
                            .Key ?? "Belirtilmemiş";
                        sw.WriteLine($"En Çok Olan Soyad: {enCokOlanSoyad}");

                        // Öğrencilerin Gano Ortalaması
                        double ganoOrtalama = OgrenciList.Rows.Cast<DataGridViewRow>()
                            .Average(r => Convert.ToDouble(r.Cells["Gano"].Value));
                        sw.WriteLine($"Öğrencilerin Gano Ortalaması: {ganoOrtalama:F2}");

                        // Bölüm sırası en yüksek olan 3 öğrenci
                        var enYuksekBolumSirasi = OgrenciList.Rows.Cast<DataGridViewRow>()
                            .OrderBy(r => Convert.ToInt32(r.Cells["BolumSira"].Value))
                            .Take(4);
                        foreach (var ogrenci in enYuksekBolumSirasi)
                        {
                            if (ogrenci.Cells["No"].Value != null)
                                sw.WriteLine($"Bölüm Sırası En Yüksek Öğrenci - No: {ogrenci.Cells["No"].Value}, İsim: {ogrenci.Cells["İsim"].Value}, Soyad: {ogrenci.Cells["Soyad"].Value}, Bölüm Sırası: {ogrenci.Cells["BolumSira"].Value}");
                        }

                        // Cinsiyet Dağılımı
                        // Cinsiyet Dağılımı
                        double erkekYuzdesi = OgrenciList.Rows.Cast<DataGridViewRow>()
                            .Count(r => r.Cells["Cinsiyet"].Value != null && r.Cells["Cinsiyet"].Value.ToString() == "Erkek") / (double)ogrenciSayisi * 100;
                        double kizYuzdesi = OgrenciList.Rows.Cast<DataGridViewRow>()
                            .Count(r => r.Cells["Cinsiyet"].Value != null && r.Cells["Cinsiyet"].Value.ToString() == "Kız") / (double)ogrenciSayisi * 100;
                        sw.WriteLine($"Erkek Öğrenci Yüzdesi: %{erkekYuzdesi:F2}");
                        sw.WriteLine($"Kız Öğrenci Yüzdesi: %{kizYuzdesi:F2}");

                    }

                    MessageBox.Show($"Rapor başarıyla oluşturuldu. Dosya Adı: {dosyaYolu}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

    }
}