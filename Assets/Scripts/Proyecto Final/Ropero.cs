using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProyectoFinal_namespace
{
    public class Ropero : MonoBehaviour
    {
        PokeIndividuo selectPokemon = new PokeIndividuo("","",0,0,"","");

        VisualElement pokemon;
        Label nombre;
        VisualElement sombrero;
        VisualElement mochila;

        VisualElement[] pokemones = new VisualElement[6];
        VisualElement[] sombreros = new VisualElement[6];
        VisualElement[] mochilas = new VisualElement[6];

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            pokemon = root.Q<VisualElement>("PokeSprite");
            nombre = root.Q<Label>("NombreRopero");
            sombrero = root.Q<VisualElement>("Sombrero");
            mochila = root.Q<VisualElement>("Mochila");
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
        }
        private void OnClickPokemon(int index)
        {
            switch (index)
            {
                case 0:
                    selectPokemon.pokemon = "pikachu";
                    break;
                case 1:
                    selectPokemon.pokemon = "Squirtle";
                    break;
                case 2:
                    selectPokemon.pokemon = "Bulbasaur";
                    break;
                case 3:
                    selectPokemon.pokemon = "Diglett";
                    break;
                case 4:
                    selectPokemon.pokemon = "Charmander";
                    break;
                case 5:
                    selectPokemon.pokemon = "Cyndaquil";
                    break;
                default:
                    break;
            }

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
    }
}

