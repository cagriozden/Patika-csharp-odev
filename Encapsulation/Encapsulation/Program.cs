using System;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {

            Ogrenci ogrenci = new Ogrenci();
            ogrenci.Isım = "cagri";
            ogrenci.Soyisim = "ozden";
            ogrenci.OgrenciNo = 399;
            ogrenci.Sinif = 4;

            ogrenci.OgrenciBilgileriniGetir();
            ogrenci.SinifArtir();
            ogrenci.OgrenciBilgileriniGetir();

        }
    }



    class Ogrenci
    {
        private string isim;

        private string soyisim;

        private int ogrenciNo;

        private int sinif;



        public string  Isım { get => isim ; set => isim = value; }
        public string Soyisim { get => soyisim; set => soyisim = value; }
        public int OgrenciNo { get => ogrenciNo; set => ogrenciNo = value; }

        public int Sinif { get => sinif; set => sinif = value; }

        public Ogrenci()
        { 
        
        }

        public Ogrenci(string isim, string soyisim, int ogrenciNo, int sinif)
        {
            Isım = isim;
            Soyisim = soyisim;
            OgrenciNo = ogrenciNo;
            Sinif = sinif;
           

        }

        public void OgrenciBilgileriniGetir()
        {

            Console.WriteLine("------Öğrenci Bilgileri------");
            Console.WriteLine("Ogrencinin Adi   :{0}", this.Isım);
            Console.WriteLine("Ogrencinin Soyisim   :{0}", this.Soyisim);
            Console.WriteLine("Ogrencinin OgrenciNo   :{0}", this.OgrenciNo);
            Console.WriteLine("Ogrencinin Sinif   :{0}", this.Sinif);


        }

        public void SinifArtir()
        {
            Sinif++;
        
        }






    }
}
