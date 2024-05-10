using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class Lab4Stats : VisualElement
{
    VisualElement NivelEscudos = new VisualElement();
    VisualElement[] EscudosArr = new VisualElement[5];

    VisualElement NivelEspadas = new VisualElement();
    VisualElement[] EspadasArr = new VisualElement[5];

    int NivelDeEscudos;
    public int Escudos
    {
        get => NivelDeEscudos;
        set{
            NivelDeEscudos = value;
            ponerNivel(EscudosArr, NivelDeEscudos);}
    }

    int NivelDeEspadas;
    public int Espadas
    {
        get => NivelDeEspadas;
        set
        {
            NivelDeEspadas = value;
            ponerNivel(EspadasArr, NivelDeEspadas);
        }
    }

    void ponerNivel(VisualElement[] ve, int _nivel)
    {
        for (int i = 0; i < ve.Length; i++)
        {
            if (i < _nivel)
            {
                ve[i].style.unityBackgroundImageTintColor = Color.white;
            }
            else
            {
                ve[i].style.unityBackgroundImageTintColor = Color.black;
            }
        }
    }
    public new class UxmlFactory : UxmlFactory<Lab4Stats, UxmlTraits> { };

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription myNivelescudos = new UxmlIntAttributeDescription { name = "Defensa", defaultValue = 0};
        UxmlIntAttributeDescription myNivelespadas = new UxmlIntAttributeDescription { name = "Ataque", defaultValue = 0 };
        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var Level = ve as Lab4Stats;
            Level.NivelDeEscudos = myNivelescudos.GetValueFromBag(bag, cc);
            Level.NivelDeEspadas = myNivelespadas.GetValueFromBag(bag, cc);
            Level.Escudos = Level.NivelDeEscudos;
            Level.Espadas = Level.NivelDeEspadas;
        }
    }

public Lab4Stats()
    {
        styleSheets.Add(Resources.Load<StyleSheet>("Practica4_StyleSheet"));
        NivelEscudos.AddToClassList("StatSS");
        NivelEscudos.style.width = 350;
        NivelEscudos.style.height = 80;
        for (int i = 0; i < EscudosArr.Length; i++)
        {
            EscudosArr[i] = new VisualElement();
            EscudosArr[i].AddToClassList("item");
            NivelEscudos.Add(EscudosArr[i]);
        }
        NivelEspadas.AddToClassList("StatSS");
        NivelEspadas.style.width = 350;
        NivelEspadas.style.height = 80;
        for (int i = 0; i < EspadasArr.Length; i++)
        {
            EspadasArr[i] = new VisualElement();
            EspadasArr[i].AddToClassList("item2");
            NivelEspadas.Add(EspadasArr[i]);
        }
        hierarchy.Add(NivelEscudos);
        hierarchy.Add(NivelEspadas);
    }
}
