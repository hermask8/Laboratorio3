using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaArbol
{
    public class Nodo<T>
    {
        public Nodo<T> izquierdo { get; set; }
        public Nodo<T> derecho { get; set; }
        public T data { get; set; }
    }

}