using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;

namespace Lab6_namespace
{
    public class Lab6 : MonoBehaviour
    {
        VisualElement botonCrear;

        VisualElement botonGuardar;

        Toggle toggleModificar;

        VisualElement contenedor_dcha;

        VisualElement avatar1;
        VisualElement avatar2;
        VisualElement avatar3;

        TextField input_nombre;
        TextField input_apellido;

        IndividuoLab6 individuoSelec;

        List<IndividuoLab6> individuoList = new List<IndividuoLab6>();

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            contenedor_dcha = root.Q<VisualElement>("derecha");
            input_nombre = root.Q<TextField>("InputNombre");
            input_apellido = root.Q<TextField>("InputApellido");
            botonCrear = root.Q<VisualElement>("BotonCrear");
            botonGuardar = root.Q<VisualElement>("BotonGuardar");
            toggleModificar = root.Q<Toggle>("ToggleModificar");
            avatar1 = root.Q("pikachu");
            avatar2 = root.Q("Squirtle");
            avatar3 = root.Q("Bulbasaur");

            Cargar();

            avatar1.RegisterCallback<ClickEvent>(SeleccionAvatar1);
            avatar2.RegisterCallback<ClickEvent>(SeleccionAvatar2);
            avatar3.RegisterCallback<ClickEvent>(SeleccionAvatar3);

            contenedor_dcha.RegisterCallback<ClickEvent>(seleccionTarjeta);
            botonCrear.RegisterCallback<ClickEvent>(NuevaTarjeta);
            botonGuardar.RegisterCallback<ClickEvent>(Guardar);
            input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);

        }
        void Guardar(ClickEvent evt)
        {
            string data = "";

            foreach (IndividuoLab6 individuo in individuoList)
            {
                data += individuo.Nombre + "," + individuo.Apellido + "," + individuo.Avatar + "\n";
            }
            File.WriteAllText("datos.txt", data);
            Debug.Log("Datos guardados en datos.txt");
        }
        void Cargar()
        {
            if (File.Exists("datos.txt"))
            {
                individuoList.Clear();

                // Leer todas las líneas del archivo
                string[] lines = File.ReadAllLines("datos.txt");

                foreach (string line in lines)
                {
                    //dividir la línea en partes utilizando la coma como separador
                    string[] parts = line.Split(',');

                    VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
                    VisualElement tarjetaPlantilla = plantilla.Instantiate();
                    tarjetaPlantilla.style.height = 200;

                    contenedor_dcha.Add(tarjetaPlantilla);
                    tarjetasHoverReset();
                    tarejetaHover(tarjetaPlantilla);

                    IndividuoLab6 individuo = new IndividuoLab6(parts[0], parts[1], parts[2]); 
                    TarjetaLab6 tarjeta = new TarjetaLab6(tarjetaPlantilla, individuo);
                    individuoSelec = individuo;

                    // Agregar el nuevo individuo a la lista
                    individuoList.Add(individuo);
                }

                Debug.Log("Datos cargados desde datos.txt");
            }
            else
            {
                Debug.Log("El archivo datos.txt no existe");
            }
        }

        void NuevaTarjeta(ClickEvent evt)
        {
            if (!toggleModificar.value)
            {
                VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Tarjeta");
                VisualElement tarjetaPlantilla = plantilla.Instantiate();
                tarjetaPlantilla.style.height = 200;

                contenedor_dcha.Add(tarjetaPlantilla);
                tarjetasHoverReset();
                tarejetaHover(tarjetaPlantilla);

                IndividuoLab6 individuo = new IndividuoLab6(input_nombre.value, input_apellido.value, "Squirtle");
                TarjetaLab6 tarjeta = new TarjetaLab6(tarjetaPlantilla, individuo);
                individuoSelec = individuo;

                individuoList.Add(individuo);
                //individuoList.ForEach(elem =>
                //{
                //    string jsonindividuo = JsonUtility.ToJson(elem);
                //    Debug.Log(jsonindividuo);
                //});
                //string listatojson = JsonHelperIndividuo.ToJson(individuoList, true);

                //File.WriteAllText("data.json", listatojson);

                //List<IndividuoLab6> jsontolista = JsonHelperIndividuo.FromJson<IndividuoLab6>(listatojson);
                //Debug.Log(jsontolista);
                //jsontolista.ForEach(elem =>
                //{
                //    Debug.Log(elem.Nombre + " " + elem.Apellido);
                //});
            }
        }

        void seleccionTarjeta(ClickEvent evt)
        {
            VisualElement elemento = evt.target as VisualElement;
            while (elemento != null)
            {
                if (elemento.userData != null)
                {
                    break;
                }
                elemento = elemento.parent;
            }
            individuoSelec = elemento.userData as IndividuoLab6;

            input_nombre.SetValueWithoutNotify(individuoSelec.Nombre);
            input_apellido.SetValueWithoutNotify(individuoSelec.Apellido);
            toggleModificar.value = true;

            tarjetasHoverReset();
            tarejetaHover(elemento);
        } 
        void CambioNombre(ChangeEvent<string> evt)
        {
            if (toggleModificar.value)
            {
                individuoSelec.Nombre = evt.newValue;
            }
        }

        void CambioApellido(ChangeEvent<string> evt)
        {
            if (toggleModificar.value)
            {
                individuoSelec.Apellido = evt.newValue;
            }
        }
        void SeleccionAvatar1(ClickEvent evt)
        {
            if (toggleModificar.value && individuoSelec != null)
            {
                individuoSelec.Avatar = "pikachu";
            }
        }

        void SeleccionAvatar2(ClickEvent evt)
        {
            if (toggleModificar.value && individuoSelec != null)
            {
                individuoSelec.Avatar = "Squirtle";
            }
        }

        void SeleccionAvatar3(ClickEvent evt)
        {
            if (toggleModificar.value && individuoSelec != null)
            {
                individuoSelec.Avatar = "Bulbasaur";
            }
        }
        void tarjetasHoverReset()
        {
            List<VisualElement> list_tarjetas = contenedor_dcha.Children().ToList();
            list_tarjetas.ForEach(elem =>
            {
                VisualElement tarjeta = elem.Q("Tarjeta");

                StyleColor azul = new StyleColor(new Color(0.0f, 0.0f, 205.0f));
                tarjeta.style.borderBottomColor = azul;
                tarjeta.style.borderTopColor = azul;
                tarjeta.style.borderLeftColor = azul;
                tarjeta.style.borderRightColor = azul;

            });
        }
        void tarejetaHover(VisualElement tar)
        {
            VisualElement tarjeta = tar.Q("Tarjeta");

            tarjeta.style.borderBottomColor = Color.white;
            tarjeta.style.borderTopColor = Color.white;
            tarjeta.style.borderLeftColor = Color.white;
            tarjeta.style.borderRightColor = Color.white;
        }

    }
}
