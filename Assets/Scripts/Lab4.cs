using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab4 : MonoBehaviour
{
    Lab4Stats stats;

    VisualElement Pokemon1;
    VisualElement Pokemon2;
    VisualElement Pokemon3;
    VisualElement Pokemon4;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Label texto = root.Q<Label>("Texto");
        texto.text = @"<i> <rotate=""20"">ESTADISTICAS DE DEFENSA Y ATAQUE</rotate>";

        stats = root.Q<Lab4Stats>("Lab4Stats");

        Pokemon1 = root.Q("Pokemon1");
        Pokemon2 = root.Q("Pokemon2");
        Pokemon3 = root.Q("Pokemon3");
        Pokemon4 = root.Q("Pokemon4");

        ResetHoverBotones();

        Pokemon1.RegisterCallback<ClickEvent>(Pokemon1level);
        Pokemon2.RegisterCallback<ClickEvent>(Pokemon2level);
        Pokemon3.RegisterCallback<ClickEvent>(Pokemon3level);
        Pokemon4.RegisterCallback<ClickEvent>(Pokemon4level);
    }

    void Pokemon1level(ClickEvent evt)
    {
        ResetHoverBotones();
        botonHover(Pokemon1);
        stats.Espadas = 3;
        stats.Escudos = 2;
    }
    void Pokemon2level(ClickEvent evt)
    {
        ResetHoverBotones();
        botonHover(Pokemon2);
        stats.Espadas = 2;
        stats.Escudos = 1;
    }
    void Pokemon3level(ClickEvent evt)
    {
        ResetHoverBotones();
        botonHover(Pokemon3);
        stats.Espadas = 4;
        stats.Escudos = 3;
    }
    void Pokemon4level(ClickEvent evt)
    {
        ResetHoverBotones();
        botonHover(Pokemon4);
        stats.Espadas = 1;
        stats.Escudos = 5;
    }
    void ResetHoverBotones()
    {
        Pokemon1.style.backgroundColor = Color.cyan;
        Pokemon2.style.backgroundColor = Color.cyan;
        Pokemon3.style.backgroundColor = Color.cyan;
        Pokemon4.style.backgroundColor = Color.cyan;
    }

    void botonHover(VisualElement boton)
    {
        boton.style.backgroundColor = Color.white;
    }
}
