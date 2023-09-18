using System;

namespace Constructor_Kavrami
{
    class Program
    {
        static void Main(string[] args)
        {

            Calisan calisan1 = new Calisan("cagri", "ozden", 123456, "SE");
            calisan1.CalisanBilgiler();

            Console.WriteLine("***********************************");

            Calisan calisan2 = new Calisan("Esma", "ozden");
            calisan2.CalisanBilgiler();


        }
    }

    class Calisan
    {
        public string Ad;
        public string Soyad;
        public int No;
        public string Departman;       



        public Calisan(string ad,string soyad, int no, string depertman)
        {
            this.Ad = ad;
            this.Soyad = soyad;
            this.No = no;
            this.Departman = depertman;

        }


        public Calisan(string ad, string soyad)
        {
            this.Ad = ad;
            this.Soyad = soyad;
        }

        public void CalisanBilgiler()
        {
            Console.WriteLine("Çalışanın adı:{0}",Ad);
            Console.WriteLine("Çalışanın soyadı:{0}", Soyad);
            Console.WriteLine("Çalışanın Numarası{0}", No);
            Console.WriteLine("Çalşınanın Departmani{0}", Departman);

        }



    }









}
