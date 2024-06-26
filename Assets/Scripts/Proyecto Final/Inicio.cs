using Lab6_namespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace ProyectoFinal_namespace
{
    public class Inicio : MonoBehaviour
    {
        VisualElement botonInicio;
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            botonInicio = root.Q("BotonInicio");
            botonInicio.RegisterCallback<ClickEvent>(changeScene);
        }
        public void changeScene(ClickEvent c)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
}
