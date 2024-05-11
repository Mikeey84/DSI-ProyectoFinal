using ProyectoFinal_namespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.IO;
using Lab5b_namespace;
using System.Xml.Linq;

namespace ProyectoFinal_namespace
{
    public class Seleccion : MonoBehaviour
    {
        bool jugar;
        VisualElement botonSeleccion;
        VisualElement tarjeta1, tarjeta2, tarjeta3, tarjeta4;
        private void OnEnable()
        {
            jugar = false;
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            botonSeleccion = root.Q("ButtonSeleccion");
            tarjeta1 = root.Q("PokeTarjeta1");
            tarjeta2 = root.Q("PokeTarjeta2");
            tarjeta3 = root.Q("PokeTarjeta3");
            tarjeta4 = root.Q("PokeTarjeta4");

            cargar();

            tarjeta1.RegisterCallback<ClickEvent>(seleccionTarjeta1);
            tarjeta2.RegisterCallback<ClickEvent>(seleccionTarjeta2);
            tarjeta3.RegisterCallback<ClickEvent>(seleccionTarjeta3);
            tarjeta4.RegisterCallback<ClickEvent>(seleccionTarjeta4);

            botonSeleccion.style.visibility = Visibility.Hidden;
            botonSeleccion.RegisterCallback<ClickEvent>(changeScene);
        }
        void seleccionTarjeta1(ClickEvent e) {
            ResetHover();
            tarjeta1.style.top = tarjeta1.resolvedStyle.top + 70;
            tarjeta1.transform.scale = new Vector3(1.1f, 1.1f, 1f);
            GuardarRanura("1");
        }
        void seleccionTarjeta2(ClickEvent e) {
            ResetHover();
            tarjeta2.style.top = tarjeta2.resolvedStyle.top + 70;
            tarjeta2.transform.scale = new Vector3(1.1f, 1.1f, 1f);
            GuardarRanura("2");
        }
        void seleccionTarjeta3(ClickEvent e) {
            ResetHover();
            tarjeta3.style.top = tarjeta3.resolvedStyle.top + 70;
            tarjeta3.transform.scale = new Vector3(1.1f, 1.1f, 1f);
            GuardarRanura("3");
        }
        void seleccionTarjeta4(ClickEvent e) {
            ResetHover();
            tarjeta4.style.top = tarjeta4.resolvedStyle.top + 70;
            tarjeta4.transform.scale = new Vector3(1.1f, 1.1f, 1f);
            GuardarRanura("4");
        }
        void GuardarRanura(string numero)
        {
            botonSeleccion.style.visibility = Visibility.Visible;
            jugar = true;
            string filePath = "ranura.txt"; // Ruta del archivo de texto

            // Escribir el número en el archivo, sobrescribiendo el contenido existente
            File.WriteAllText(filePath, numero);
        }
        void ResetHover()
        {
            tarjeta1.transform.scale = new Vector3(1f, 1f, 1f);
            tarjeta2.transform.scale = new Vector3(1f, 1f, 1f);
            tarjeta3.transform.scale = new Vector3(1f, 1f, 1f);
            tarjeta4.transform.scale = new Vector3(1f, 1f, 1f);
            tarjeta1.style.top = 0;
            tarjeta2.style.top = 0;
            tarjeta3.style.top = 0;
            tarjeta4.style.top = 0;
        }
        public void changeScene(ClickEvent c)
        {
            if (jugar)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        void cargar()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            if (File.Exists("datos.txt"))
            {
                // Leer todas las líneas del archivo
                string[] lines = File.ReadAllLines("datos.txt");
                int i = 1;
                foreach (string line in lines)
                {
                    //dividir la línea en partes utilizando la coma como separador
                    string[] parts = line.Split(',');
                    if (parts.Length >= 6)
                    {
                        VisualElement ranura = root.Q("PokeTarjeta" + i);
                        VisualElement pokemonvisible = ranura.Q("Pokemon");
                        Label _nombre = ranura.Q<Label>("NombreTarjeta");
                        VisualElement _pokemon = ranura.Q("PokeSprite");
                        VisualElement _sombrero = ranura.Q("Sombrero");
                        VisualElement _mochila = ranura.Q("Mochila");
                        Lab4Stats stats = ranura.Q<Lab4Stats>("Lab4Stats");

                        PokeIndividuo pokeIndividuo = new PokeIndividuo(parts[0], parts[1], int.Parse(parts[2]),
                             int.Parse(parts[3]), parts[4], parts[5]);

                        pokemonvisible.style.visibility = Visibility.Visible;
                        _nombre.text = pokeIndividuo.nombre;
                        _pokemon.style.backgroundImage = Resources.Load<Sprite>(pokeIndividuo.pokemon).texture;
                        _sombrero.style.backgroundImage = Resources.Load<Sprite>(pokeIndividuo.sombrero).texture;
                        _mochila.style.backgroundImage = Resources.Load<Sprite>(pokeIndividuo.mochila).texture;
                        stats.Espadas = pokeIndividuo.ataque;
                        stats.Escudos = pokeIndividuo.defensa;
                    }
                    else
                    {
                        Debug.LogError("La línea en datos.txt no contiene suficientes elementos.");
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