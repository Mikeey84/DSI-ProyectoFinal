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
        PokeIndividuo pokeIndividuo;
        VisualElement pokemon;
        Label nombre;
        VisualElement sombrero;
        VisualElement mochila;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            pokemon = root.Q<VisualElement>("PokeSprite");
            nombre = root.Q<Label>("Nomre");
            sombrero = root.Q<VisualElement>("Sombrero");
            mochila = root.Q<VisualElement>("Mochila");

            cargar();

            Sprite imagen = Resources.Load<Sprite>(pokeIndividuo.pokemon);
            pokemon.style.backgroundImage = imagen.texture;

            Sprite somb = Resources.Load<Sprite>(pokeIndividuo.sombrero);
            sombrero.style.backgroundImage = somb.texture;

            Sprite mochi = Resources.Load<Sprite>(pokeIndividuo.mochila);
            mochila.style.backgroundImage = mochi.texture;

            nombre.text = pokeIndividuo.nombre;
        }



        void cargar()
        {
            if (File.Exists("datos.txt"))
            {
                //individuoList.Clear();

                // Leer todas las líneas del archivo
                string[] lines = File.ReadAllLines("datos.txt");

                foreach (string line in lines)
                {
                    //dividir la línea en partes utilizando la coma como separador
                    string[] parts = line.Split(',');

                   pokeIndividuo = new PokeIndividuo(parts[0], parts[1], int.Parse(parts[2]),
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

