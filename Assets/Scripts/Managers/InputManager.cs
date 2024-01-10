using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action OnExited;
    public event Action<Vector3> OnSelected;
    public event Action<Vector3> OnInteracted;
    void OnExit()
    {
        OnExited?.Invoke();
    }
    void OnSelect()
    {
        OnSelected?.Invoke(Input.mousePosition);
    }
    void OnInteract()
    {
        OnInteracted?.Invoke(Input.mousePosition);
    }
}
