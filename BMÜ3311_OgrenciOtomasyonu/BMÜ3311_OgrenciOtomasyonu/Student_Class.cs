using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BMU3311_VeriYonetimi
{
    internal class Student_Class
    {
        public static List<Student_Class.Student> Students = new List<Student_Class.Student>();
        static Random random = new Random(); //Rastgele sayı almak için
        private static string[] erkekIsimleri = new string[45]
        {
            "Ahmet", "Mehmet", "Murat", "Ali", "Can", "Eren", "Emir", "Murat", "Berk", "Kerem",
            "Onur", "Ozan", "Tolga", "Umut", "Cem", "Barış", "Yusuf", "Furkan", "Yasin", "Serkan",
            "Sinan", "Kaan", "Oğuz", "Kadir", "Mustafa", "İsmail", "Bilal", "Ege", "Orhan", "Emre",
            "Yunus", "Efe", "Osman", "Halil", "Enes", "Tarık", "Fikret", "Cihan", "Ege", "Metin","Haluk",
            "Nezih","Timur","Hilmi","Tayyip"
        };
        private static string[] kizIsimleri = new string[40]
        {
            "Ayşe", "Fatma", "Aysel", "Nur", "Elif", "Sedef", "Aslı", "Ebru", "Ceren", "Zeynep",
            "Merve", "Hilal", "Sude", "Sema", "Büşra", "Hande", "Esra", "Gizem", "Ezgi", "Cemre",
            "Deniz", "Şeyma", "Gamze", "Asuman", "Derya", "İrem", "Leyla", "Özge", "Pınar", "Sibel",
            "Sezen", "Tuğçe", "Yağmur", "Zehra", "Hümeyra", "Meryem", "Nihan", "Emine", "Gül", "Filiz"
        };
        private static string[] Soyadlar = new string[55]
        {
            "Yılmaz", "Demir", "Çelik", "Kaya", "Koç", "Şahin", "Türk", "Güneş", "Acar", "Toprak",
            "Yıldız", "Kurt", "Öztürk", "Çetin", "Turan", "Yılgın", "Dere", "Yaprak", "Kor", "Sarıçiçek",
            "Kaynak", "Korkmaz", "Bulut", "Doğulu", "Çoban", "Umut", "Seyran", "Ay", "Yol", "Mavi",
            "Yıldırım", "Dilek", "Bedir", "Koraslan", "Eser", "Su", "Genç", "Beroje", "Salcı", "Abrak",
            "Abdullah", "Bingöl", "Kalkan", "Babalar", "Çay","Gül","Aslan","Kaplan","Güney","Kara","Kandemir",
            "Şen","Tüten","Yüzbaşıoğlu","Kulaksız"
        };

        public static List<Student> Sinif1 = new List<Student>();
        public static List<Student> Sinif2 = new List<Student>();
        public static List<Student> Sinif3 = new List<Student>();
        public static List<Student> Sinif4 = new List<Student>();
        public struct Student
        {
            public string Cinsiyet;
            public string İsim;
            public string Soyad;
            public int No;
            public float Gano;
            public int BolumSira;
            public int SınıfSira;
            public int Sınıf;
        }                                    //Öğrenci için struct
        public static Student CreateRandomStudent()
        {
            Student student = new Student();

            student.Cinsiyet = RandCinsiyet();
            student.İsim = RastgeleAdal(student.Cinsiyet);
            student.Soyad = RastgeleSoyadAl();
            student.No = RastgeleOgrenciNo();
            student.Gano = RastgeleGanoDegeri();
            student.Sınıf = RastgeleSınıfAl();

            switch (student.Sınıf)
            {
                case 1:
                    Sinif1.Add(student);
                    break;
                case 2:
                    Sinif2.Add(student);
                    break;
                case 3:
                    Sinif3.Add(student);
                    break;
                case 4:
                    Sinif4.Add(student);
                    break;    
            }

            return student;
        }
        private static int RastgeleSınıfAl()
        {
            while (true)
            {
                int SınıfSec = random.Next(1, 5);
                if (SınıfSec == 1 && Sinif1.Count < 2500)
                {
                    return 1;

                }
                else if (SınıfSec == 2 && Sinif2.Count < 2500)
                {
                    return 2;
                }
                else if (SınıfSec == 3 && Sinif3.Count < 2500)
                {
                    return 3;
                }
                else if(Sinif4.Count<2500)
                {
                    return 4;
                }
            }
        }

        public static List<int> kullanilanNumaralar = new List<int>();
        private static int RastgeleOgrenciNo()
        {
            int ogrenciNo;
            do
            {
                ogrenciNo = random.Next(1, 10001);
            } while (kullanilanNumaralar.Contains(ogrenciNo));

            kullanilanNumaralar.Add(ogrenciNo);
            return ogrenciNo;
        }
        private static float RastgeleGanoDegeri()
        {
            // Rastgele bir float sayı oluştur, virgül sonrası 3 basamaklı
            float gano = (float)Math.Round(random.NextDouble() * 3 + 1, 3);
            return gano;
        }
        private static string RandCinsiyet()
        {
            if (random.Next(2) == 0)
                return "Erkek";
            else
                return "Kız";
        }
        private static string RastgeleAdal(string Cinsiyet)
        {
            if (Cinsiyet.Equals("Erkek"))
                return erkekIsimleri[random.Next(erkekIsimleri.Length)];
            else
                return kizIsimleri[random.Next(kizIsimleri.Length)];
        }
        private static string RastgeleSoyadAl()
        {
            return Soyadlar[random.Next(Soyadlar.Length)];
        }
        public static void BolumSirala()
        {
            List<Student> tempstudents = Students.OrderByDescending(student => student.Gano).ToList();
            Students.Clear();
            int n=tempstudents.Count;
            for (int i = 0; i < n; ++i)
            {
                Student s = tempstudents[i];
                s.BolumSira = (i + 1);
                Students.Add(s);
            }

        }
        public static void SiniflariSırala()
        {
            Sinif1= Students.Where(o => o.Sınıf == 1).ToList();
            Sinif2= Students.Where(o => o.Sınıf == 2).ToList();
            Sinif3= Students.Where(o => o.Sınıf == 3).ToList();
            Sinif4= Students.Where(o => o.Sınıf == 4).ToList();


            Sinif1 = Sinif1.OrderByDescending(Student => Student.Gano).ToList();
            Sinif2 = Sinif2.OrderByDescending(Student => Student.Gano).ToList();
            Sinif3 = Sinif3.OrderByDescending(Student => Student.Gano).ToList();
            Sinif4 = Sinif4.OrderByDescending(Student => Student.Gano).ToList();

            int n = Sinif1.Count;
            Students.Clear();
            for (int i = 0; i < n; ++i)
            {
                Student x = Sinif1[i], y = Sinif2[i], z = Sinif3[i], w= Sinif4[i];
                x.SınıfSira = (i + 1); y.SınıfSira = (i + 1); z.SınıfSira = (i + 1); w.SınıfSira = (i + 1);
                Students.AddRange( new List<Student>{ x,y,z,w});
            }
        }
    }
}
