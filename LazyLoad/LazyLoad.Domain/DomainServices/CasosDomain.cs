using LazyLoad.Domain.DomainContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Domain.DomainServices
{
    public class CasosDomain: ICasosDomain
    {
        //private ? ObtenerCasos(List<int> elementos)

        private int CalcularViajes(List<int> elementos)
        {
            //elementos =  { 32, 56, 76, 8, 44, 60, 47, 85, 71, 91 };

            Console.WriteLine("carga peresoza");
            //se ordenan los elementos
            elementos = elementos.OrderByDescending(x => x).ToList();
            int elementosEnLaBolsa = 1;
            int indiceElementoMayorCargado = 0;
            int indiceElementoMenorCargado = elementos.Count - 1;
            int cantidadDeViajes = 0;
            while (indiceElementoMayorCargado < indiceElementoMenorCargado)
            {
                while (elementos[indiceElementoMayorCargado] * elementosEnLaBolsa < 50)
                {
                    elementosEnLaBolsa++;
                    if (elementosEnLaBolsa > elementos.Count) { break; }
                }
                indiceElementoMayorCargado++;
                indiceElementoMenorCargado = indiceElementoMenorCargado - elementosEnLaBolsa + 1;
                cantidadDeViajes++;
                elementosEnLaBolsa = 0;
            }
            return cantidadDeViajes;
        }
    }
}
