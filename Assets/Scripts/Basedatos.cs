using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab5b_namespace
{
    public class Basedatos
    {
        public static List<Individuo> getData()
        {
            List<Individuo> datos = new List<Individuo>();

            Individuo carlos = new Individuo("Carlos", "Gomez", "pikachu");
            Individuo marcos = new Individuo("Marcos", "Pantoja", "Squirtle");
            Individuo daniel = new Individuo("Daniel", "Moreno", "Bulbasaur");
            Individuo miguel = new Individuo("Miguel Angel", "Nosepo", "Squirtle");
            
            datos.Add(carlos);
            datos.Add(marcos);
            datos.Add(daniel);
            datos.Add(miguel);
            
            return datos;
        }
    }
}
