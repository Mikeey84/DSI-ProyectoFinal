using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab5b_namespace
{
    public class Individuo
    {
        public event Action Cambio;

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if(value != nombre)
                {
                    nombre = value;
                    Cambio?.Invoke();
                }
            }
        }
        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (value != apellido)
                {
                    apellido = value;
                    Cambio?.Invoke();
                }
            }
        }

        private string avatar;
        public string Avatar
        {
            get { return avatar; }
            set
            {
                if (value != avatar)
                {
                    avatar = value;
                    Cambio?.Invoke();
                }
            }
        }

        public Individuo(string nombre, string apellido, string avatar)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.avatar = avatar;
        }
    }
}
