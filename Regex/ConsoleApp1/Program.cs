

using System.Collections;

internal class Program
{
    static int sayac = 0;
    static int kontrol = 1;
    static ArrayList okunan = new ArrayList();
    static ArrayList ifadeayristir = new ArrayList();
    static Stack stack = new Stack();
    static Stack stack1 = new Stack();
    static string baskontrol = "";
    static string sonkontrol = " ";
    static string gelen;
    private static void Main(string[] args)
    {

        Console.Write("Alfabe Giriniz: ");
        string L = Console.ReadLine();
        string[] alfabe = L.Split(',');
        ArrayList convertalfabe = new ArrayList();
        foreach (string s in alfabe)
        {
            convertalfabe.Add(s);
        }

        Console.Write("Düzenli İfadeyi Giriniz: ");
        string ifade = " ";
        ifade = Console.ReadLine();
        ifadeoku(ifade);
        Console.Write("Kaç Adet Göreceksiniz: ");
        int adet = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < convertalfabe.Count; i++)
        {
            okunan.Insert(i, convertalfabe[i]);
        }
        AlfabeYap(convertalfabe, adet);


        //EkranaBas(okunan, adet);
         foreach (string s in okunacak)
             Console.Write(s + ",");
    }
    static int ekranabassayac = 0;
    static ArrayList okunacak = new ArrayList();
    static void EkranaBas(ArrayList dizi, int adet)
    {
        if (ekranabassayac >= adet)
            return;
        foreach (string s in dizi)
        {
            //baskontrol = s.StartsWith('a').ToString();
            //sonkontrol = s.Substring(s.Length - 1, 1);
            if (s.StartsWith('a') == true && s.EndsWith('b') == true)
            {
                Console.WriteLine(s);
                ekranabassayac++;
                if (ekranabassayac >= adet)
                    return;
            }
        }
        /* if (ekranabassayac < adet)
          {
             AlfabeYap(okunacak, 50);
             EkranaBas(okunan, adet);
          }*/

    }

    // ( 40 )=41
    //* = 42

    static ArrayList list = new ArrayList();
    static ArrayList Harf = new ArrayList();
    static string bas = " ", son = " ";
    static void ifadeoku(string ifade)
    {
        char karakter;
        string aktar;
        int kontrol = 0;
        for (int i = 0; i < ifade.Length; i++)
        {
            karakter = char.Parse(ifade.Substring(i, 1));
            if ((int)karakter >= 97 && (int)karakter <= 122 && kontrol == 0)
            {
                if (i == 0)
                    list.Add(karakter + "1");
                else if (i == ifade.Length - 1)
                    list.Add(karakter + "2");
                else
                    list.Add(karakter);
                Console.Write(karakter.ToString() + " ");
            }
            else if ((int)karakter == 40 || kontrol == 1)
            {
                kontrol = 1;
                Harf.Add(karakter);
                if (karakter == ')')
                {
                    kontrol = 0;
                }
            }
        }
        string deger;

        for (int i = 0; i < list.Count; i++)
        {
            deger = list[i].ToString();
            if (deger.Substring(deger.Length - 1, 1) == "1")
            {
                bas = deger.Substring(0, 1);
            }
            else if (deger.Substring(deger.Length - 1, 1) == "2")
            {
                son = deger.Substring(0, 1);
            }

        }
        Console.WriteLine("bas: " + bas);
        Console.WriteLine("son: " + son);
    }



    static int count = 0;
    static int say1 = 0;
    static void AlfabeYap(ArrayList alfabe, int adet)
    {
        count = alfabe.Count;
        if (say1 >= adet || count == 0) return;
        for (int i = 0; i < count; i++)
        {
            for (int j = i; j < count; j++)
            {
                for (int k = 0; k < okunan.Count; k++)
                {
                    if (alfabe[i].ToString() + alfabe[j].ToString() == okunan[k].ToString())
                    {
                        kontrol = 0;
                        break;
                    }
                    else kontrol = 1;
                }

                if (kontrol == 1)
                {
                    gelen = alfabe[i].ToString() + alfabe[j].ToString();
                    okunan.Add(alfabe[i].ToString() + alfabe[j].ToString());
                    sayac++;
                    if (gelen.Substring(0,1) == "a" && gelen.Substring(gelen.Length-1 ,1) == "b")
                    {
                        say1++;
                        okunacak.Add(gelen);
                    }
                    kontrol = 0;
                }
                if (say1 >= adet) return;

            }
        }
        AlfabeYap(okunan, adet);
    }
}
