using LazyLoad.Domain.DomainContracts;
using LazyLoad.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Domain.DomainServices
{
    public class CasoDomain: ICasoDomain
    {
        //private ? ObtenerCasos(List<int> elementos)

        public int CalcularViajes(Caso caso)
        {
         
            //se ordenan los elementos
            List<Elemento> elementos=caso.Elemento.OrderByDescending(x => x.Valor).ToList();
            int elementosEnLaBolsa = 1;
            int indiceElementoMayorCargado = 0;
            int indiceElementoMenorCargado = elementos.Count - 1;
            int cantidadDeViajes = 0;
            while (indiceElementoMayorCargado < indiceElementoMenorCargado)
            {
                while (elementos[indiceElementoMayorCargado].Valor * elementosEnLaBolsa < 50)
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
