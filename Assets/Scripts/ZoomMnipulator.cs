using UnityEngine;
using UnityEngine.UIElements;

public class ZoomManipulator : MouseManipulator
{
    private Vector3 m_StartSize;

    public ZoomManipulator()
    {
        activators.Add(new ManipulatorActivationFilter { button = MouseButton.MiddleMouse });
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<WheelEvent>(OnWheelEvent);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<WheelEvent>(OnWheelEvent);
    }

    protected void OnWheelEvent(WheelEvent e)
    {
        float delta = -e.delta.y * 0.01f; // Obtener el desplazamiento de la rueda del ratón

        // Establecer la nueva escala del elemento
        if((target.transform.scale.x >= 0.5 && delta < 0) || (target.transform.scale.x <= 2 && delta > 0))
        {
            target.transform.scale += new Vector3(delta, delta, 0.0f);
        }
        e.StopPropagation();
    }
}
