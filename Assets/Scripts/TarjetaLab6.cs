using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Lab6_namespace
{
    public class TarjetaLab6
    {

        IndividuoLab6 miIndividuo;

        VisualElement tarjetaRoot;

        Label nombreLabel;
        Label apellidoLabel;
        VisualElement avatar;
        Sprite avatarSprite;

        public TarjetaLab6(VisualElement tarjetaRoot, IndividuoLab6 individuo)
        {
            this.tarjetaRoot = tarjetaRoot;
            this.miIndividuo = individuo;

            nombreLabel = tarjetaRoot.Q<Label>("Nombre");
            apellidoLabel = tarjetaRoot.Q<Label>("Apellido");
            avatar = tarjetaRoot.Q("top");

            tarjetaRoot.userData = miIndividuo;

            UpdateUI();

            miIndividuo.Cambio += UpdateUI;
        }

        void UpdateUI()
        {
            nombreLabel.text = miIndividuo.Nombre;
            apellidoLabel.text = miIndividuo.Apellido;
            avatarSprite = Resources.Load<Sprite>(miIndividuo.Avatar);
            avatar.style.backgroundImage = avatarSprite.texture;
        }
    }
}
