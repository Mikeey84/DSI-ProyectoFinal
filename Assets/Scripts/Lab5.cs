using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab5 : MonoBehaviour
{
    VisualElement plantilla;

    VisualElement avatar1;
    VisualElement avatar2;
    VisualElement avatar3;

    VisualElement avatarasignado;

    TextField input_nombre;
    TextField input_apellido;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        plantilla = root.Q("MainPlantilla");
        avatar1 = root.Q("pikachu");
        avatar2 = root.Q("Squirtle");
        avatar3 = root.Q("Bulbasaur");
        avatarasignado = plantilla.Q("top");
        input_nombre = root.Q<TextField>("InputNombre");
        input_apellido = root.Q<TextField>("InputApellido");

        plantilla.RegisterCallback<ClickEvent>(SeleccionIndividuo);
        input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);

        // Agregar los eventos de clic a los avatares
        avatar1.RegisterCallback<ClickEvent>(SeleccionAvatar1);
        avatar2.RegisterCallback<ClickEvent>(SeleccionAvatar2);
        avatar3.RegisterCallback<ClickEvent>(SeleccionAvatar3);
    }

    void SeleccionIndividuo(ClickEvent evt)
    {
        string nombre = plantilla.Q<Label>("Nombre").text;
        string apellido = plantilla.Q<Label>("Apellido").text;

        Debug.Log(nombre);

        input_nombre.SetValueWithoutNotify(nombre);
        input_apellido.SetValueWithoutNotify(apellido);
    }

    void CambioNombre(ChangeEvent<string> evt)
    {
        Label nombreLabel = plantilla.Q<Label>("Nombre");
        nombreLabel.text = evt.newValue;
    }

    void CambioApellido(ChangeEvent<string> evt)
    {
        Label apellidoLabel = plantilla.Q<Label>("Apellido");
        apellidoLabel.text = evt.newValue;
    }

    void SeleccionAvatar1(ClickEvent evt)
    {
        CambiarSprite(avatar1);
    }

    void SeleccionAvatar2(ClickEvent evt)
    {
        CambiarSprite(avatar2);
    }

    void SeleccionAvatar3(ClickEvent evt)
    {
        CambiarSprite(avatar3);
    }

    void CambiarSprite(VisualElement avatar)
    {
        // Obtener el nombre del sprite del avatar clicado
        string spriteName = avatar.name;

        // Cargar el sprite desde los recursos
        Sprite sprite = Resources.Load<Sprite>(spriteName);

        // Asignar el sprite al avatar asignado
        Texture2D backgroundImage = sprite.texture;
        avatarasignado.style.backgroundImage = backgroundImage;
    }
}
