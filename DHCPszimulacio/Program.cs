using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DHCPszimulacio
{
    
    class Program
    {
        static List<string> excluded = new List<string>();

        static void BeolvasExcluded()
        {
            try
            {
                StreamReader file = new StreamReader("excluded.csv");
                try
                {
                    while (!file.EndOfStream)
                    {
                        excluded.Add(file.ReadLine());
                    }
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    file.Close();
                }
                file.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        static string CimEggyelNo(string cim)
        {
            /*
             szétvágni '.'
             az utolsót int-á konvertálni
             egyet hozzáaadni (255 ne lépjük túl)

             összefűzni string-é
             */
            string[] adatok = cim.Split('.');
            int okt4 = Convert.ToInt32(adatok[3]);
            if (okt4 < 255)
            {
                okt4++;
            }
            return adatok[0] + "." + adatok[1] + "." + adatok[2] + "." + okt4.ToString();
        }

        static void Main(string[] args)
        {
            BeolvasExcluded();
            //foreach (var e in excluded)
            //{
            //    Console.WriteLine(e);
            //}
            //Console.WriteLine("\nVége-----------------------");
            Console.ReadKey();
        }
    }
}
