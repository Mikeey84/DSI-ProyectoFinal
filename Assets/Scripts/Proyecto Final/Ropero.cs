using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProyectoFinal_namespace
{
    public class Ropero : MonoBehaviour
    {
        VisualElement[] pokemones = new VisualElement[6];
        VisualElement[] sombreros = new VisualElement[6];
        VisualElement[] mochilas = new VisualElement[6];

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            // Asignación de los pokemones
            for (int i = 0; i < pokemones.Length; i++)
            {
                pokemones[i] = root.Q($"Pokemon{i + 1}");
                pokemones[i].RegisterCallback<ClickEvent>((evt) => OnClickPokemon(i));
            }

            // Asignación de los sombreros
            for (int i = 0; i < sombreros.Length; i++)
            {
                sombreros[i] = root.Q($"Sombrero{i + 1}");
                sombreros[i].RegisterCallback<ClickEvent>((evt) => OnClickSombrero(i));
            }

            // Asignación de las mochilas
            for (int i = 0; i < mochilas.Length; i++)
            {
                mochilas[i] = root.Q($"Mochila{i + 1}");
                mochilas[i].RegisterCallback<ClickEvent>((evt) => OnClickMochila(i));
            }
        }
        private void OnClickPokemon(int index)
        {
            
        }

        private void OnClickSombrero(int index)
        {
        }

        private void OnClickMochila(int index)
        {
        }
    }
}

