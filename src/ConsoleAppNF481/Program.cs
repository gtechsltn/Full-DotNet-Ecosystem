using ClassLibraryNS20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNF481
{
    class Program
    {
        static void Main(string[] args)
        {
            IDBHelper dBHelper = new DBHelper();

            //Using Simple Transaction
            dBHelper.InsertCustomer1();

            //Using Transaction Scope
            dBHelper.InsertCustomer2();

            //Using Dapper Transaction
            dBHelper.InsertCustomer3();
        }
    }
}
