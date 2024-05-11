using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using Lab6_namespace;
using ProyectoFinal_namespace;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

namespace ProyectoFinal_namespace
{
    public class Final : MonoBehaviour
    {
        PokeIndividuo pokeIndividuo = new PokeIndividuo("", "pikachu", 0, 0, "Sombrero4", "Mochila1");
        VisualElement pokemon;
        Label nombre;
        VisualElement sombrero;
        VisualElement mochila;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            pokemon = root.Q<VisualElement>("PokeSprite");
            nombre = root.Q<Label>("Nombre");
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
            int ranura = 1;
            if (File.Exists("ranura.txt"))
            {
                string line = File.ReadLines("ranura.txt").Last();
                ranura = int.Parse(line);
            }
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            if (File.Exists("datos.txt"))
            {
                // Leer todas las líneas del archivo
                string[] lines = File.ReadAllLines("datos.txt");
                int i = 1;
                foreach (string line in lines)
                {
                    if (i == ranura)
                    {
                        string[] parts = line.Split(',');

                        pokeIndividuo = new PokeIndividuo(parts[0], parts[1], int.Parse(parts[2]),
                             int.Parse(parts[3]), parts[4], parts[5]);

                        nombre.text = pokeIndividuo.nombre;
                        pokemon.style.backgroundImage = Resources.Load<Sprite>(pokeIndividuo.pokemon).texture;
                        sombrero.style.backgroundImage = Resources.Load<Sprite>(pokeIndividuo.sombrero).texture;
                        mochila.style.backgroundImage = Resources.Load<Sprite>(pokeIndividuo.mochila).texture;
                    }
                    i++;
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

