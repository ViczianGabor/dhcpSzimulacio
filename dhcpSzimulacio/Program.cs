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
        static Dictionary<string, string> reserved = new Dictionary<string, string>();
        static Dictionary<string, string> dhcp = new Dictionary<string, string>();
        static List<string> commands = new List<string>();

        static void BeolvasList(List<string> l, string filenev)
        {
            try
            {
                StreamReader file = new StreamReader(filenev);
                try
                {
                    while (!file.EndOfStream)
                    {
                        l.Add(file.ReadLine());
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




        

        static void Beolvdictionary(Dictionary<string,string> d, string filenev)
        {
            try
            {
                StreamReader file = new StreamReader(filenev);
                while (!file.EndOfStream)
                {
                    string[] adatok = file.ReadLine().Split(';');
                        d.Add(adatok[0], adatok[1]);
                }

                file.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }

            
        }

        static void Main(string[] args)
        {
            BeolvasList(excluded, "excludeed.csv");
            BeolvasList(commands, "test.csv");
            Beolvdictionary(dhcp,"dhcp.csv");
            Beolvdictionary(reserved, "reserved.csv");
            //foreach (var i in dhcp)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine("Vége...... \n");


            foreach (var m in commands)
            {
                Console.WriteLine(m);
            }


            Console.WriteLine("Vége...... \n");












            Console.ReadKey();
        }
    }
}
