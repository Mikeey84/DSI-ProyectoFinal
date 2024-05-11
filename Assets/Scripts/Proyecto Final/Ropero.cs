using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.IO;
using System.Linq;
using Lab6_namespace;
using Lab5b_namespace;
using System;

namespace ProyectoFinal_namespace
{
    public class Ropero : MonoBehaviour
    {
        PokeIndividuo selectPokemon = new PokeIndividuo("", "pikachu", 0, 0, "Sombrero4", "Mochila1");

        TextField nombre;
        VisualElement pokemon;
        VisualElement sombrero;
        VisualElement mochila;
        Lab4Stats stats;

        VisualElement botonSiguiente;

        VisualElement[] pokemones = new VisualElement[6];
        VisualElement[] sombreros = new VisualElement[6];
        VisualElement[] mochilas = new VisualElement[6];

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            pokemon = root.Q<VisualElement>("PokeSprite");
            nombre = root.Q<TextField>("NombreRopero");
            sombrero = root.Q<VisualElement>("Sombrero");
            mochila = root.Q<VisualElement>("Mochila");
            stats = root.Q<Lab4Stats>("Lab4Stats");
            botonSiguiente = root.Q<VisualElement>("BotonSiguente");
            // Asignación y registro de callbacks de clic para los pokemones
            for (int i = 0; i < pokemones.Length; i++)
            {
                int currentIndex = i; // Captura el valor actual de i
                pokemones[i] = root.Q($"Pokemon{i + 1}");
                pokemones[i].RegisterCallback<ClickEvent>((evt) => OnClickPokemon(currentIndex));
            }

            // Asignación y registro de callbacks de clic para los sombreros
            for (int i = 0; i < sombreros.Length; i++)
            {
                int currentIndex = i; // Captura el valor actual de i
                sombreros[i] = root.Q($"Sombrero{i + 1}");
                sombreros[i].RegisterCallback<ClickEvent>((evt) => OnClickSombrero(currentIndex));
            }

            // Asignación y registro de callbacks de clic para las mochilas
            for (int i = 0; i < mochilas.Length; i++)
            {
                int currentIndex = i; // Captura el valor actual de i
                mochilas[i] = root.Q($"Mochila{i + 1}");
                mochilas[i].RegisterCallback<ClickEvent>((evt) => OnClickMochila(currentIndex));
            }
            nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            botonSiguiente.RegisterCallback<ClickEvent>(changeScene);
            cargar();
        }
        public void changeScene(ClickEvent c)
        {
            guarda();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        void CambioNombre(ChangeEvent<string> evt)
        {
            selectPokemon.Nombre = evt.newValue;
        }
        private void OnClickPokemon(int index)
        {
            switch (index)
            {
                case 0:
                    selectPokemon.pokemon = "pikachu";
                    selectPokemon.ataque = 4;
                    selectPokemon.defensa = 2;
                    break;
                case 1:
                    selectPokemon.pokemon = "Squirtle";
                    selectPokemon.ataque = 3;
                    selectPokemon.defensa = 3;
                    break;
                case 2:
                    selectPokemon.pokemon = "Bulbasaur";
                    selectPokemon.ataque = 2;
                    selectPokemon.defensa = 4;
                    break;
                case 3:
                    selectPokemon.pokemon = "Diglett";
                    selectPokemon.ataque = 1;
                    selectPokemon.defensa = 5;
                    break;
                case 4:
                    selectPokemon.pokemon = "Charmander";
                    selectPokemon.ataque = 5;
                    selectPokemon.defensa = 3;
                    break;
                case 5:
                    selectPokemon.pokemon = "Cyndaquil";
                    selectPokemon.ataque = 3;
                    selectPokemon.defensa = 1;
                    break;
                default:
                    break;
            }

            stats.Espadas = selectPokemon.ataque;
            stats.Escudos = selectPokemon.defensa;
            Sprite imagen = Resources.Load<Sprite>(selectPokemon.pokemon);
            pokemon.style.backgroundImage = imagen.texture;
        }

        private void OnClickSombrero(int index)
        {
            switch (index)
            {
                case 0:
                    selectPokemon.sombrero = "Sombrero1";
                    break;
                case 1:
                    selectPokemon.sombrero = "Sombrero2";
                    break;
                case 2:
                    selectPokemon.sombrero = "Sombrero3";
                    break;
                case 3:
                    selectPokemon.sombrero = "Sombrero4";
                    break;
                case 4:
                    selectPokemon.sombrero = "Sombrero5";
                    break;
                case 5:
                    selectPokemon.sombrero = "Sombrero6";
                    break;
                default:
                    break;
            }
            Sprite imagen = Resources.Load<Sprite>(selectPokemon.sombrero);
            sombrero.style.backgroundImage = imagen.texture;
        }

        private void OnClickMochila(int index)
        {
            switch (index)
            {
                case 0:
                    selectPokemon.mochila = "Mochila1";
                    break;
                case 1:
                    selectPokemon.mochila = "Mochila2";
                    break;
                case 2:
                    selectPokemon.mochila = "Mochila3";
                    break;
                case 3:
                    selectPokemon.mochila = "Mochila4";
                    break;
                case 4:
                    selectPokemon.mochila = "Mochila5";
                    break;
                case 5:
                    selectPokemon.mochila = "Mochila6";
                    break;
                default:
                    break;
            }
            Sprite imagen = Resources.Load<Sprite>(selectPokemon.mochila);
            mochila.style.backgroundImage = imagen.texture;
        }
        void guarda()
        {
            int ranura = 1;
            string data = selectPokemon.nombre + "," + selectPokemon.pokemon + "," + selectPokemon.ataque + "," +
                          selectPokemon.defensa + "," + selectPokemon.sombrero + "," + selectPokemon.mochila + "\n";

            if (File.Exists("ranura.txt"))
            {
                string line = File.ReadLines("ranura.txt").Last();
                ranura = int.Parse(line);
            }

            string[] lineas = File.Exists("datos.txt") ? File.ReadAllLines("datos.txt") : new string[0];

            if (ranura <= lineas.Length)
            {
                lineas[ranura - 1] = data; // Ajusta el índice a base 0
            }
            else
            {
                Array.Resize(ref lineas, ranura);
                lineas[ranura - 1] = data;
            }

            File.WriteAllLines("datos.txt", lineas);
            Debug.Log("Datos guardados en datos.txt");
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

                        selectPokemon = new PokeIndividuo(parts[0], parts[1], int.Parse(parts[2]),
                             int.Parse(parts[3]), parts[4], parts[5]);

                        nombre.SetValueWithoutNotify(selectPokemon.nombre);
                        pokemon.style.backgroundImage = Resources.Load<Sprite>(selectPokemon.pokemon).texture;
                        sombrero.style.backgroundImage = Resources.Load<Sprite>(selectPokemon.sombrero).texture;
                        mochila.style.backgroundImage = Resources.Load<Sprite>(selectPokemon.mochila).texture;
                        stats.Espadas = selectPokemon.ataque;
                        stats.Escudos = selectPokemon.defensa;
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

