using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dhcpSzimulacio
{
    class Program
    {
        static List<string> excluded = new List<string>();
        static List<string> reserved = new List<string>();


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
                catch (Exception ed)
                {

                    Console.WriteLine(ed.Message);
                }
                finally
                {
                    file.Close();
                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }

        }





        static string CimEggyelNo(string cim)
        {
            ///cim = 192.168.10.100 
            ///return 192.168.10.101
            ///Szétvágni '.'
            ///az utolsó int-é konvertálni és egyet hozzáadni (255 ne lépje túl)
            ///összefűzni string-é

            string[] adat = cim.Split('.');
            int okt4 = Convert.ToInt32(adat[3]);
            if (okt4 <255)
            {
                okt4++;
            }

            return adat[0] + "." + adat[1] + "." + adat[2] + "." + okt4.ToString();

            


        }



        static void Main(string[] args)
        {
            BeolvasExcluded();


            //foreach (var i in excluded)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine("Vége...... \n");


            
            
                
            












            Console.ReadKey();
        }
    }
}
