using System;

namespace Sınıf_Nedir_Instance_F_eld_Property
{
    class Program
    {
        static void Main(string[] args)
        {

            Calisan calisan1 = new Calisan();
            calisan1.Ad = "Cagri";
            calisan1.Soyad = "Ozden";
            calisan1.No = 23425634;
            calisan1.Departman = "SE";

            calisan1.CalisanBilgileri();

            Console.WriteLine("*************");


            Calisan calisan2 = new Calisan();
            calisan2.Ad = "murat";
            calisan2.Soyad = "dal";
            calisan2.No = 123456;
            calisan2.Departman = "se";

            calisan2.CalisanBilgileri();
        }

        class Calisan
        {

            public string Ad;

            public string Soyad;

            public int No;

            public string Departman;

            public void CalisanBilgileri()
            {

                Console.WriteLine("Çalışanın Adı:{0}", Ad);
                Console.WriteLine("Çalışanın Soyadı:{0}", Soyad);
                Console.WriteLine("Çalışanın Numarası:{0}", No);
                Console.WriteLine("Çalışanın Deparman:{0}", Departman);
            }

        }
    }
}
