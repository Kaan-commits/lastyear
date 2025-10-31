using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Iyi
{
    internal class DatabaseManager
    {
        Database _db;
        //method injection ve property injection göstermek için yazılmıştır ctor
        public DatabaseManager(Database db)
        {
            //ctor injector
            _db = db;
        }

        public List<string> Listele()
        {
            return _db.listele();
        }

        //property injection
        public Database PropInjection
        {
            get { return _db; }
            set { _db = value; }
        }

        //method injection
        public void MethodInjection(Database db)
        {
            _db = db;
        }
    }
}