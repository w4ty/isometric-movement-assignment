using Unity.VisualScripting;
using UnityEngine;

public interface IMoveable
{
    float Speed { get; set; }
    float Agility { get; set; }

    void Move(Vector3 position);
}
