using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProyectoFinal_namespace
{
    [System.Serializable]
    public class PokeIndividuo
    {
        public event Action Cambio;

        public string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value != nombre)
                {
                    nombre = value;
                    Cambio?.Invoke();
                }
            }
        }
        public string pokemon;
        public string Pokemon
        {
            get { return pokemon; }
            set
            {
                if (value != pokemon)
                {
                    pokemon = value;
                    Cambio?.Invoke();
                }
            }
        }
        public int ataque;
        public int Ataque
        {
            get { return ataque; }
            set
            {
                if (value != ataque)
                {
                    ataque = value;
                    Cambio?.Invoke();
                }
            }
        }

        public int defensa;
        public int Defensa
        {
            get { return defensa; }
            set
            {
                if (value != defensa)
                {
                    defensa = value;
                    Cambio?.Invoke();
                }
            }
        }
        public string sombrero;
        public string Sombrero
        {
            get { return sombrero; }
            set
            {
                if (value != sombrero)
                {
                    sombrero = value;
                    Cambio?.Invoke();
                }
            }
        }
        public string mochila;
        public string Mochila
        {
            get { return mochila; }
            set
            {
                if (value != mochila)
                {
                    mochila = value;
                    Cambio?.Invoke();
                }
            }
        }

        public PokeIndividuo(string nombre, string pokemon, int ataque, int defensa,string sombrero, string mochila)
        {
            this.nombre = nombre;
            this.pokemon = pokemon;
            this.ataque = ataque;
            this.defensa = defensa;
            this.sombrero = sombrero;
            this.mochila = mochila;
        }
    }
}