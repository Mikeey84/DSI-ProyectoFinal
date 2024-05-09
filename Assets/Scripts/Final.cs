using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using Lab6_namespace;
using ProyectoFinal_namespace;

namespace ProyectoFinal_namespace
{
    public class Final : MonoBehaviour
    {
        VisualElement pokemon;
        Label nombre;
        VisualElement sombrero;
        VisualElement mochila;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            pokemon = root.Q<VisualElement>("Pokemon");
            nombre = root.Q<Label>("Nomre");
            sombrero = root.Q<VisualElement>("Sombrero");
            mochila = root.Q<VisualElement>("Mochila");

            cargar();
        }



        void cargar()
        {
            if (File.Exists("datos.txt"))
            {
                //individuoList.Clear();

                // Leer todas las l�neas del archivo
                string[] lines = File.ReadAllLines("datos.txt");

                foreach (string line in lines)
                {
                    //dividir la l�nea en partes utilizando la coma como separador
                    string[] parts = line.Split(',');

                    PokeIndividuo pokemon = new PokeIndividuo(parts[0], parts[1], int.Parse(parts[2]),
                        int.Parse(parts[3]), parts[4], parts[5]);
                }

                Debug.Log("Datos cargados desde datos.txt");
            }
            else
            {
                Debug.Log("El archivo datos.txt no existe");
            }
        }
    }

}
