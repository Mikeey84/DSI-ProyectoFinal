using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab2 : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        UQueryBuilder<VisualElement> builder = new(rootve);
        
        //para los pokemos
        List<VisualElement> lista_VisElem = rootve.Query(className: "pokemon_style").ToList();
        lista_VisElem.ForEach(elem => { elem.AddToClassList("pokemon_style2"); });

        // para los botones
        Button ataque_but = rootve.Q<Button>("Ataque");
        ataque_but.style.fontSize = 18;
        ataque_but.style.backgroundColor = Color.red;

        Button esquivar_but = rootve.Q<Button>("Esquivar");
        esquivar_but.style.fontSize = 18;
        esquivar_but.style.backgroundColor = Color.green;

        Button habilidad_but = rootve.Q<Button>("Habilidad");
        habilidad_but.style.fontSize = 18;
        habilidad_but.style.backgroundColor = Color.cyan;

        // Menu de Skills
        VisualElement mSkills = rootve.Q<VisualElement>("Skills");
        mSkills.style.backgroundColor = Color.gray;

        //Barras de progreso(ataque, agilidad y resistencia)
        ProgressBar poder = rootve.Q<ProgressBar>("Poder");
        poder.value = 30;

        ProgressBar agilidad = rootve.Q<ProgressBar>("Agilidad");
        agilidad.value = 70;

        ProgressBar resistencia = rootve.Q<ProgressBar>("Resistencia");
        resistencia.value = 50;


    }
}
