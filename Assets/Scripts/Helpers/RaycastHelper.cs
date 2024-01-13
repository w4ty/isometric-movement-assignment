using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public static bool IsAnyRaycastableAt(Vector3 origin)
    {
        return GetRaycastableAt(origin) != null;
    }
    public static Vector3 GetRayPos(Vector3 origin)
    {
        Ray ray = Camera.main.ScreenPointToRay(origin);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
