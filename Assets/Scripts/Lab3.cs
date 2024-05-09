using UnityEngine;
using UnityEngine.UIElements;

public class Lab3 : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement izquierda = root.Q("Izquierda");
        VisualElement derecha = root.Q("Derecha");

        AddManipulatorToChildren(izquierda);
        AddManipulatorToChildren(derecha);
    }

    private void AddManipulatorToChildren(VisualElement parent)
    {
        foreach (var child in parent.Children())
        {
            child.AddManipulator(new Lab3Manipulator());
            child.AddManipulator(new ZoomManipulator());
        }
    }
}
