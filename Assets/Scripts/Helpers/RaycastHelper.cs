using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHelper : MonoBehaviour
{
    public static IRaycastable GetRaycastableAt(Vector3 origin)
    {
        Ray ray = Camera.main.ScreenPointToRay(origin);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) 
        {
            hit.collider.TryGetComponent(out IRaycastable raycastable);
            return raycastable;
        }
        return null;
    }
}
