using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    public event Action<ISelectable> OnSelectable;
    public event Action<Vector3> OnWalkable;

    private void OnSelected(Vector3 origin)
    {
        var target = RaycastHelper.GetRaycastableAt(origin);
        if (target is ISelectable selectable)
        {
            OnSelectable?.Invoke(selectable);
        }
    }

    private void OnInteracted(Vector3 origin)
    {
        var target = RaycastHelper.GetRaycastableAt(origin);
        if (target is IUseable useable)
        {
            Debug.Log(useable);
        }
        else if (!RaycastHelper.IsAnyRaycastableAt(origin))
        {
            OnWalkable?.Invoke(RaycastHelper.GetRayPos(origin));
        }
    }

    private void Awake()
    {
        if (inputManager != null)
        {
            inputManager.OnSelected += OnSelected;
            inputManager.OnInteracted += OnInteracted;
        }
    }
    private void OnDestroy()
    {
        if (inputManager != null) 
        { 
            inputManager.OnSelected -= OnSelected;
            inputManager.OnInteracted -= OnInteracted;
        }
    }
}
