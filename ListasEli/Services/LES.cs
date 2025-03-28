using System.Reflection.Metadata.Ecma335;
using ListasEli.Models;
using Microsoft.AspNetCore.Components;

namespace ListasEli.Services
{
    public class LES
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public LES()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        bool EstaVacia()
        {
            return PrimerNodo == null;
        }

        public string AgregarNodoFinal(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            return "Nodo agregado al final de la lista";
        }
        public string AgregarNodoInicio(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
            return "Nodo agregado al final de la lista";
        }
        public string AgregarNodoDespuesDe(string informacion, Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                return "La lista está vacía";
            }

            Nodo? actual = PrimerNodo;
            while (actual != null)
            {
                if (actual.Informacion == informacion)
                {
                    nuevoNodo.Referencia = actual.Referencia;
                    actual.Referencia = nuevoNodo;

                    if (actual == UltimoNodo)
                    {
                        UltimoNodo = nuevoNodo;
                    }

                    return "Nodo agregado después del valor especificado";
                }
                actual = actual.Referencia;
            }
            return "Valor no encontrado en la lista";
        }
        public string AgregarNodoAntesDe(string informacion, Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                return "La lista está vacía";
            }
            // Caso especial: insertar antes del primer nodo
            if (PrimerNodo.Informacion == informacion)
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
                return "Nodo agregado al inicio";
            }

            Nodo? anterior = null;
            Nodo? actual = PrimerNodo;

            while (actual != null)
            {
                if (actual.Informacion == informacion)
                {
                    // Enlazamos correctamente los nodos
                    anterior.Referencia = nuevoNodo;
                    nuevoNodo.Referencia = actual;
                    return "Nodo agregado antes del valor especificado";
                }
                anterior = actual;
                actual = actual.Referencia;
            }
            return "Valor no encontrado en la lista";
        }

        public string AgregarDespuesDePosicion(int posicion, Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                return "esta vacia";
            }
            Nodo? actual = PrimerNodo;
            int contador = 0;
            while (actual != null && contador < posicion)
            {
                actual = actual.Referencia;
            }
            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;
            if (actual == UltimoNodo)
            {
                UltimoNodo = nuevoNodo;
            }
            return "NodoAgregado";
        }

        public string AgregarAntesDePosicion(int posicion, Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                return "esta vacia";
            }
            Nodo? actual = PrimerNodo;
            Nodo anterior = null;
            int contador = 0;
            while (actual != null && contador < posicion)
            {
                anterior = actual;
                actual = actual.Referencia;
                contador++;
            }
            anterior.Referencia = nuevoNodo;
            nuevoNodo.Referencia = actual;
            return "Nodo ha sido agregado";
        }

        public string EliminarInicio()
        {
            if (EstaVacia()) return "La lista está vacía";
            PrimerNodo = PrimerNodo.Referencia;
            if (PrimerNodo == null) UltimoNodo = null;
            return "Nodo eliminado del inicio";
        }
        public string EliminarFinal()
        {
            if (EstaVacia()) return "La lista está vacía";
            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
                return "Nodo eliminado del final";
            }
            Nodo actual = PrimerNodo;
            while (actual.Referencia != UltimoNodo)
            {
                actual = actual.Referencia;
            }
            actual.Referencia = null;
            UltimoNodo = actual;
            return "Nodo eliminado del final";
        }
        public string EliminarAntesDe(string dato)
        {
            if (EstaVacia() || PrimerNodo.Informacion == dato) return "No se puede eliminar";
            if (PrimerNodo.Referencia != null && PrimerNodo.Referencia.Informacion == dato)
            {
                PrimerNodo = PrimerNodo.Referencia;
                return "Nodo eliminado";
            }
            Nodo actual = PrimerNodo;
            Nodo previo = null;
            while (actual.Referencia != null && actual.Referencia.Informacion != dato)
            {
                previo = actual;
                actual = actual.Referencia;
            }
            if (actual.Referencia == null) return "Dato no encontrado";
            previo.Referencia = actual.Referencia;
            return "Nodo eliminado antes del dato";
        }

        public string EliminarDespuesDe(string dato)
        {
            Nodo actual = PrimerNodo;
            while (actual != null && actual.Informacion != dato)
            {
                actual = actual.Referencia;
            }
            if (actual == null || actual.Referencia == null) return "No se puede eliminar";
            actual.Referencia = actual.Referencia.Referencia;
            if (actual.Referencia == null) UltimoNodo = actual;
            return "Nodo eliminado después del dato";
        }

        public string EliminarEnPosicion(int posicion)
        {
            if (EstaVacia() || posicion < 0) return "Posición inválida";
            if (posicion == 0) return EliminarInicio();
            Nodo actual = PrimerNodo;
            Nodo previo = null;
            int index = 0;
            while (actual != null && index < posicion)
            {
                previo = actual;
                actual = actual.Referencia;
                index++;
            }
            if (actual == null) return "Posición fuera de rango";
            previo.Referencia = actual.Referencia;
            if (actual == UltimoNodo) UltimoNodo = previo;
            return "Nodo eliminado en la posición " + posicion;
        }
        public void OrdenarLista()
        {
            if (EstaVacia() || PrimerNodo.Referencia == null) return;
            bool intercambiado;
            do
            {
                intercambiado = false;
                Nodo actual = PrimerNodo;
                while (actual.Referencia != null)
                {
                    if (string.Compare(actual.Informacion, actual.Referencia.Informacion) > 0)
                    {
                        string temp = actual.Informacion;
                        actual.Informacion = actual.Referencia.Informacion;
                        actual.Referencia.Informacion = temp;
                        intercambiado = true;
                    }
                    actual = actual.Referencia;
                }
            } while (intercambiado);
        }

        public string EliminarEnPosicionEspe(int posicion)
        {
            if (EstaVacia()) return "La lista está vacía.";
            if (posicion < 0) return "Posición inválida.";

            if (posicion == 0) return EliminarInicio(); // Si es la primera posición

            Nodo actual = PrimerNodo;
            Nodo previo = null;
            int index = 0;

            while (actual != null && index < posicion)
            {
                previo = actual;
                actual = actual.Referencia;
                index++;
            }

            if (actual == null) return "Posición fuera de rango.";

            previo.Referencia = actual.Referencia; // Saltar el nodo a eliminar

            if (actual == UltimoNodo) UltimoNodo = previo; // Si era el último, actualizar

            return "Nodo eliminado en la posición " + posicion;
        }


    }
}