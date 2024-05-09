using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab6_namespace
{
    public static class JsonHelperIndividuo
    {
        public static List<IndividuoLab6> FromJson<IndividuoLab6>(string json)
        {
            ListaIndividuo<IndividuoLab6> listaIndividuo = JsonUtility.FromJson<ListaIndividuo<IndividuoLab6>>(json);
            return listaIndividuo.Individuos;
        }
        public static string ToJson<IndividuoLab6>(List<IndividuoLab6> lista)
        {
            string json = JsonUtility.ToJson(lista);
            return json;
        }
        public static string ToJson<IndividuoLab6>(List<IndividuoLab6> lista, bool prettyPrint)
        {
            string json = JsonUtility.ToJson(lista, prettyPrint);
            return json;
        }
        [SerializeField]
        private class ListaIndividuo<IndividuoLab6>
        {
            public List<IndividuoLab6> Individuos;
        }
    }
}
