using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab6_namespace
{
    [System.Serializable]
    public class IndividuoLab6
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
        public string apellido;
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

        public string avatar;
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

        public IndividuoLab6(string nombre, string apellido, string avatar)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.avatar = avatar;
        }
    }
}
