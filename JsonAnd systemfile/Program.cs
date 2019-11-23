using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systemfile;
using Newtonsoft.Json;


namespace JsonAnd_systemfile
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            /////////////////////////////////////////////// 
            Class_cash saveCash = new Class_cash("MEMBERCASH.TSHPANDA", "TheDirectory");
            string JsonFromCash = saveCash.TextFromFile();
            List<ClassToCash> ListOfMembers;
            if (string.IsNullOrEmpty(JsonFromCash))

            {
                ListOfMembers = new List<ClassToCash>();
            }
            else
            {
               
                ListOfMembers = JsonConvert.DeserializeObject<List<ClassToCash>>(JsonFromCash);  
               
            }

            ///////////////////////////////////////////////////
            Console.Write($"Tedad afrade mojood  {ListOfMembers.Count} Mibashad EzafeKardane nafare jadid \"y\"");
            string flag = Console.ReadLine().ToLower();
            if (flag == "y")
            {

                Console.Write("Chand nafar Register Beshavand ? ");
                int Tedad = Convert.ToInt32(Console.ReadLine());
                for (int i = 0 ; i < Tedad; i++)
                {
                    ClassToCash cash = new ClassToCash();
                    cash.id = i;
                    Console.Write("Name Of Member : ");
                    cash.Name = Console.ReadLine();
                    ListOfMembers.Add(cash);
                }

            }

            Console.WriteLine("Members ====> ");
            for (int i = 0; i < ListOfMembers.Count; i++)
            {
                Console.WriteLine($"id : {ListOfMembers[i].id} AND Name : {ListOfMembers[i].Name}");
            }
            int iii = SaveCash(ListOfMembers);
            switch (iii)
            {
                case 1:
                    Console.WriteLine("Cash Saved Done!");
                    break;
                case -1:
                    Console.WriteLine("Failed !");
                    break;
                case -2:
                    Console.WriteLine("Failed !");
                    break;
                default:
                    Console.WriteLine("Nothing!");
                    break;
            }
            Console.ReadLine();
           
        }


        /////////////////////////////////////////////////////////////////

        public static int SaveCash(List<ClassToCash> TOCASH)
        {
            string JsonSerialized = JsonConvert.SerializeObject(TOCASH);
            Class_cash saveCash = new Class_cash("MEMBERCASH.TSHPANDA", "TheDirectory");
            int res = 0;
            try
            {
                res = saveCash.Write_ToFile(JsonSerialized, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            return res;
        }


    }
}
   