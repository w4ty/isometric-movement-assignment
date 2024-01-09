using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCharacter : MonoBehaviour, IMoveable, IKillable
{
    public float Speed { get; set; }
    public float Agility { get; set; }
    public float Health { get; set; }

    public void Move(Vector3 position)
    {
        Debug.Log("Moving");
    }
    public void Death()
    {
        Debug.Log("Dying");
    }

}
