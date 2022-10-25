
using System.Collections;

internal class Program
{
    static ArrayList okunan = new ArrayList();
    static ArrayList list = new ArrayList();
    static ArrayList okunacak = new ArrayList();
    static int count = 0, say1 = 0, sayac = 0, kontrol = 1,basmi=0;
    static string bas = " ", son = " ", orta = " ",gelen;

    private static void Main(string[] args)
    {
        Console.Write("Alfabe Giriniz: ");
        string L = Console.ReadLine();
        string[] alfabe = L.Split(',');
        ArrayList convertalfabe = new ArrayList();
        foreach (string s in alfabe)
            convertalfabe.Add(s);

        Console.Write("Düzenli İfadeyi Giriniz: ");
        string ifade = " ";
        ifade = Console.ReadLine();
        ifadeoku(ifade);
        Console.Write("Kaç Adet Göreceksiniz: ");
        int adet = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < convertalfabe.Count; i++)
            okunan.Insert(i, convertalfabe[i]);
        AlfabeYap(convertalfabe, adet);

        foreach (string s in okunacak)
            Console.Write(s + ",");
    }

    static void ifadeoku(string ifade)
    {
        char karakter;
        int kontrol = 0;
        for (int i = 0; i < ifade.Length; i++)
        {
            karakter = char.Parse(ifade.Substring(i, 1));
            if ((int)karakter >= 97 && (int)karakter <= 122 && kontrol == 0)
            {
                if (i == 0 && ifade.Substring(1, 1) != "*")
                {
                    list.Add(karakter + "1"); //ab*b
                    basmi = 1;
                }              
                else if (i == 0 && ifade.Substring(1, 1) == "*")
                    list.Add(karakter + "*");
                else if (i == ifade.Length - 1)
                    list.Add(karakter + "/");
                else
                {
                    if (ifade.Substring(i + 1, 1) == "*")
                        list.Add(karakter + "*");
                }
                //Console.Write(karakter.ToString() + " ");
            }
        }
        string deger;
        for (int i = 0; i < list.Count; i++)
        {
            deger = list[i].ToString();
            if (deger.Substring(deger.Length - 1, 1) == "1")
                bas = deger.Substring(0, 1);
            else if (deger.Substring(deger.Length - 1, 1) == "*" && basmi == 0)
            {
                bas = deger.Substring(0, 1);
                orta = deger.Substring(0, 1);
            }
            else if (deger.Substring(deger.Length - 1, 1) == "/")
                son = deger.Substring(0, 1);
            else if (deger.Substring(deger.Length - 1, 1) == "*")
                orta = deger.Substring(i - 1, 1);
        }
        Console.Write("Baş Karakter: " + bas);
        Console.Write("\tSon Karakter: " + son);
        Console.Write("\tOrta Karakter: " + orta);
    }

    static void AlfabeYap(ArrayList alfabe, int adet)
    {
        bool bak = false;
        count = alfabe.Count;
        if (say1 >= adet || count == 0) return;
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
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
                    if (gelen.Substring(0, 1) == bas && gelen.Substring(gelen.Length - 1, 1) == son && bas != " " && son != " ")
                    {
                        if (gelen.Length <= 2)
                            bak = true;
                        else
                        {
                            bak = false;
                            for (int k = 1; k <= gelen.Length - 2; k++)
                            {
                                if (gelen.Substring(k, 1) == orta)
                                    bak = true;
                                else
                                {
                                    bak = false;
                                    break;
                                }
                            }
                        }
                        if (bak == true)
                        {
                           // Console.WriteLine("oldu: " + gelen);
                            okunacak.Add(gelen);
                            sayac++;
                            say1++;
                        }
                        // else
                        //Console.WriteLine("olmadı: " + gelen);
                    }
                    kontrol = 0;
                }
                if (say1 >= adet) return;
            }
        }
        AlfabeYap(okunan, adet);
    }
}


