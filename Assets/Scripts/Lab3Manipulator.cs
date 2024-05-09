using UnityEngine;
using UnityEngine.UIElements;

public class Lab3Manipulator : MouseManipulator
{
    public Lab3Manipulator()
    {
        activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseEnterEvent>(OnMouseEnter);
        target.RegisterCallback<MouseLeaveEvent>(OnMouseLeave);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseEnterEvent>(OnMouseEnter);
        target.UnregisterCallback<MouseLeaveEvent>(OnMouseLeave);
    }

    protected void OnMouseEnter(MouseEnterEvent e)
    {
        target.style.borderBottomColor = Color.white;
        target.style.borderLeftColor = Color.white;
        target.style.borderTopColor = Color.white;
        target.style.borderRightColor = Color.white;
        e.StopPropagation();
    }

    protected void OnMouseLeave(MouseLeaveEvent e)
    {
        target.style.borderBottomColor = Color.black;
        target.style.borderLeftColor = Color.black;
        target.style.borderTopColor = Color.black;
        target.style.borderRightColor = Color.black;
        e.StopPropagation();
    }
}

