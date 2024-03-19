using ClassLibraryNS20;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceNF481
{
    public partial class SampleServiceNF : ServiceBase
    {
        public SampleServiceNF()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            IDBHelper dBHelper = new DBHelper();

            //Using Simple Transaction
            dBHelper.InsertCustomer1();

            //Using Transaction Scope
            dBHelper.InsertCustomer2();

            //Using Dapper Transaction
            dBHelper.InsertCustomer3();
        }

        protected override void OnStop()
        {
        }
    }
}
