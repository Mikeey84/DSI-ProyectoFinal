using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

namespace Lab5b_namespace
{
    public class Lab5b : MonoBehaviour
    {
        List<Individuo> individuos;

        Individuo selecIndividuo;

        VisualElement avatar1;
        VisualElement avatar2;
        VisualElement avatar3;

        TextField input_nombre;
        TextField input_apellido;

        VisualElement tarjeta1, tarjeta2, tarjeta3, tarjeta4;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            tarjeta1 = root.Q("Tarjeta1");
            tarjeta2 = root.Q("Tarjeta2");
            tarjeta3 = root.Q("Tarjeta3");
            tarjeta4 = root.Q("Tarjeta4");

            avatar1 = root.Q("pikachu");
            avatar2 = root.Q("Squirtle");
            avatar3 = root.Q("Bulbasaur");

            input_nombre = root.Q<TextField>("InputNombre");
            input_apellido = root.Q<TextField>("InputApellido");

            individuos = Basedatos.getData();

            VisualElement panelDerecho = root.Q("derecha");
            panelDerecho.RegisterCallback<ClickEvent>(seleccionTarjeta);

            avatar1.RegisterCallback<ClickEvent>(SeleccionAvatar1);
            avatar2.RegisterCallback<ClickEvent>(SeleccionAvatar2);
            avatar3.RegisterCallback<ClickEvent>(SeleccionAvatar3);

            input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);

            InitializeUI();
        }
        void CambioNombre(ChangeEvent<string> evt)
        {
            selecIndividuo.Nombre = evt.newValue;
        }

        void CambioApellido(ChangeEvent<string> evt)
        {
            selecIndividuo.Apellido = evt.newValue;
        }
        void SeleccionAvatar1(ClickEvent evt)
        {
            if(selecIndividuo != null){
                selecIndividuo.Avatar = "pikachu";
            }
        }

        void SeleccionAvatar2(ClickEvent evt)
        {
            if (selecIndividuo != null)
            {
                selecIndividuo.Avatar = "Squirtle";
            }
        }

        void SeleccionAvatar3(ClickEvent evt)
        {
            if (selecIndividuo != null)
            {
                selecIndividuo.Avatar = "Bulbasaur";
            }
        }

        void seleccionTarjeta(ClickEvent e)
        {
            VisualElement elemento = e.target as VisualElement;
            while (elemento != null)
            {
                // Verifica si el elemento es la tarjeta que estás buscando
                if (elemento.userData != null)
                {
                    // Realiza las operaciones que necesites con el elemento
                    break;
                }
                // Si no es la tarjeta que estás buscando, sube un nivel en la jerarquía
                elemento = elemento.parent;
            }
            selecIndividuo = elemento.userData as Individuo;

            tarjeta1.style.top = 0;
            tarjeta2.style.top = 0;
            tarjeta3.style.top = 0;
            tarjeta4.style.top = 0;

            elemento.style.top = tarjeta1.resolvedStyle.top + 20;

            input_nombre.SetValueWithoutNotify(selecIndividuo.Nombre);
            input_apellido.SetValueWithoutNotify(selecIndividuo.Apellido);
        }

        void InitializeUI()
        {
            Tarjeta tar1 = new Tarjeta(tarjeta1, individuos[0]);
            Tarjeta tar2 = new Tarjeta(tarjeta2, individuos[1]);
            Tarjeta tar3 = new Tarjeta(tarjeta3, individuos[2]);
            Tarjeta tar4 = new Tarjeta(tarjeta4, individuos[3]);
        }
    }
}
