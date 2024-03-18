using ClassLibraryNS20;
using System;

namespace ConsoleAppNC8
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
