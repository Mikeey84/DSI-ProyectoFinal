using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Seleccion : MonoBehaviour
{
    VisualElement botonSeleccion;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        botonSeleccion = root.Q("ButtonSeleccion");
        botonSeleccion.RegisterCallback<ClickEvent>(changeScene);
    }
    public void changeScene(ClickEvent c)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
