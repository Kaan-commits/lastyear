using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_I
{
    internal class Ferrari : IAraba
    {
        public string Renk { get; set; }
        
        public void Sur()
        {
            System.Console.WriteLine("Ferrari sürülüyor.");
        }
    }
}