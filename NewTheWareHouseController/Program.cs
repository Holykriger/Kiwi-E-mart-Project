using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTheWareHouseController
{
    //Locations are bad WTF Shall WareHouse Have Location in sted of base values ???
    class Program
    {
        static void Main(string[] args)
        {
            //This is for testing
            Console.WriteLine("This is a Test Run");
            WareHouseController WHC = new WareHouseController();
            WHC.Start();
   
            Console.ReadLine();
        }
    }
    
}
