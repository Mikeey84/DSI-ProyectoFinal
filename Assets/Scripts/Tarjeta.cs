using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

namespace Lab5b_namespace
{ 
    public class Tarjeta
    {

        Individuo miIndividuo;

        VisualElement tarjetaRoot;

        Label nombreLabel;
        Label apellidoLabel;
        VisualElement avatar;
        Sprite avatarSprite;

        public Tarjeta(VisualElement tarjetaRoot, Individuo individuo)
        {
            this.tarjetaRoot = tarjetaRoot;
            this.miIndividuo = individuo;

            nombreLabel = tarjetaRoot.Q<Label>("Nombre");
            apellidoLabel = tarjetaRoot.Q<Label>("Apellido");
            avatar = tarjetaRoot.Q("top");

            tarjetaRoot.userData = miIndividuo;

            tarjetaRoot
                .Query(className: "tarjeta")
                .Descendents<VisualElement>()
                .ForEach(elem => elem.pickingMode = PickingMode.Ignore);
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
