using Lab6_namespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace ProyectoFinal_namespace
{
    public class ProyectoFinal : MonoBehaviour
    {
        VisualElement botonCrear;

        VisualElement botonGuardar;

        Toggle toggleModificar;

        VisualElement contenedor_dcha;

        VisualElement avatar1;
        VisualElement avatar2;
        VisualElement avatar3;

        VisualElement botonInicio;

        TextField input_nombre;
        TextField input_apellido;

        IndividuoLab6 individuoSelec;
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            botonInicio = root.Q("Button");
            botonInicio.RegisterCallback<ClickEvent>(changeScene);
        }
        public void changeScene(ClickEvent c)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
}
