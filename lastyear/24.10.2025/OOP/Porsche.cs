using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_I
{
    internal class Porsche : IAraba
    {
        public string Renk { get; set; }
        
        public void Sur()
        {
            System.Console.WriteLine("Porsche sürülüyor.");
        }
    }
}