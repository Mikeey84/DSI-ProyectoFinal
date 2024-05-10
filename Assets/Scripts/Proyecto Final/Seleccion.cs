using ProyectoFinal_namespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.IO;
using Lab5b_namespace;

namespace ProyectoFinal_namespace
{
    public class Seleccion : MonoBehaviour
    {
        Lab4Stats stats1, stats2, stats3, stats4;
        PokeIndividuo pokeIndividuo;
        VisualElement botonSeleccion;
        VisualElement tarjeta1, tarjeta2, tarjeta3, tarjeta4;
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            botonSeleccion = root.Q("ButtonSeleccion");

            cargar();

            botonSeleccion.RegisterCallback<ClickEvent>(changeScene);
            tarjeta1.RegisterCallback<ClickEvent>(changeScene);
        }
        public void changeScene(ClickEvent c)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        void cargar()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            if (File.Exists("datos.txt"))
            {
                //individuoList.Clear();

                // Leer todas las líneas del archivo
                string[] lines = File.ReadAllLines("datos.txt");
                int i = 1;
                foreach (string line in lines)
                {
                    //dividir la línea en partes utilizando la coma como separador
                    string[] parts = line.Split(',');
                    VisualElement ranura = root.Q("PokeTarjeta" + i);
                    Label _nombre = ranura.Q<Label>("NombreTarjeta");
                    VisualElement _pokemon = ranura.Q("PokeSprite");
                    VisualElement _sombrero = ranura.Q("Sombrero");
                    VisualElement _mochila = ranura.Q("Mochila");
                    Lab4Stats stats = ranura.Q<Lab4Stats>("Lab4Stats");

                    pokeIndividuo = new PokeIndividuo(parts[0], parts[1], int.Parse(parts[2]),
                         int.Parse(parts[3]), parts[4], parts[5]);

                    _nombre.text = pokeIndividuo.nombre;
                    _pokemon.style.backgroundImage = Resources.Load<Sprite>(pokeIndividuo.pokemon).texture;
                    _sombrero.style.backgroundImage = Resources.Load<Sprite>(pokeIndividuo.sombrero).texture;
                    _mochila.style.backgroundImage = Resources.Load<Sprite>(pokeIndividuo.mochila).texture;
                    stats.Espadas = pokeIndividuo.ataque;
                    stats.Escudos = pokeIndividuo.defensa;

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