using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaArbol;

namespace LibreriaArbol
{
    public class ArbolAvl<T> where T:IComparable
    {
        Nodo<T> raiz;

        public void Insertar(T dtInfo)
        {
            Nodo<T> ntemp = new Nodo<T>();
            //ntemp = null;
            ntemp.data = dtInfo;
            ntemp.derecho = null;
            ntemp.izquierdo = null;

            if (raiz == null)
            {
                raiz = ntemp;
            }
            else
            {
                Nodo<T> nAux = raiz;
                Nodo<T> nPafre = raiz;
                bool bDerecha = false;
                while (nAux != null)
                {

                    nPafre = nAux;
                    if (dtInfo.CompareTo(nAux.data) == 1)
                    {
                        nAux = nAux.derecho;
                        bDerecha = true;
                    }
                    else
                    {
                        nAux = nAux.izquierdo;
                        bDerecha = false;
                    }
                }
                if (bDerecha == true)
                {
                    nPafre.derecho = ntemp;
                }
                else
                {
                    nPafre.izquierdo = ntemp;
                }

            }
        }

        public void Balancear()
        {
            raiz = BalancearArbol(raiz);
        }
        private Nodo<T> BalancearArbol(Nodo<T> IngresoRaiz)
        {
            int b_factor = VerificarBalance(IngresoRaiz);
            if (b_factor > 1)
            {
                if (VerificarBalance(IngresoRaiz.izquierdo) > 0)
                {
                    IngresoRaiz = RotarLL(IngresoRaiz);
                }
                else
                {
                    IngresoRaiz = RotarLR(IngresoRaiz);
                }
            }
            else if (b_factor < -1)
            {
                if (VerificarBalance(IngresoRaiz.derecho) > 0)
                {
                    IngresoRaiz = RotarRL(IngresoRaiz);
                }
                else
                {
                    IngresoRaiz = RotarRR(IngresoRaiz);
                }
            }
            return IngresoRaiz;
        }

        private int RetornarAltura(Nodo<T> IngresoRaiz)
        {
            int altura = 0;
            if (IngresoRaiz != null)
            {
                int l = RetornarAltura(IngresoRaiz.izquierdo);
                int r = RetornarAltura(IngresoRaiz.derecho);
                int m = max(l, r);
                altura = m + 1;
            }
            return altura;
        }
        private int VerificarBalance(Nodo<T> current)
        {
            int alturaIzquieda = RetornarAltura(current.izquierdo);
            int alturaDerecha = RetornarAltura(current.derecho);
            int b_factor = alturaIzquieda - alturaDerecha;
            return b_factor;
        }

        private int max(int l, int r)
        {
            return l > r ? l : r;
        }

        private Nodo<T> RotarRR(Nodo<T> rotar)
        {
            Nodo<T> pivote = rotar.derecho;
            rotar.derecho = pivote.izquierdo;
            pivote.izquierdo = rotar;
            return pivote;
        }
        private Nodo<T> RotarLL(Nodo<T> rotar)
        {
            Nodo<T> pivote = rotar.izquierdo;
            rotar.izquierdo = rotar.derecho;
            pivote.derecho = rotar;
            return pivote;
        }
        private Nodo<T> RotarLR(Nodo<T> rotar)
        {
            Nodo<T> pivote = rotar.izquierdo;
            rotar.izquierdo = RotarRR(pivote);
            return RotarLL(rotar);
        }
        private Nodo<T> RotarRL(Nodo<T> rotar)
        {
            Nodo<T> pivote = rotar.derecho;
            rotar.derecho = RotarLL(pivote);
            return RotarRR(rotar);
        }

    }
}
