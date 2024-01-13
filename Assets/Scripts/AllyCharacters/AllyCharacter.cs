using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCharacter : MonoBehaviour, IMoveable, IKillable, ISelectable, IRaycastable
{
    public CharacterDataScriptableObject CharacterData;

    public float Speed { get; set; }
    public float Agility { get; set; }
    public float Health { get; set; }

    void Awake()
    {
        Speed = Random.Range(CharacterData.SpeedMinMax.x, CharacterData.SpeedMinMax.y);
        Agility = Random.Range(CharacterData.AgilityMinMax.x, CharacterData.AgilityMinMax.y);
        Health = Mathf.RoundToInt(Random.Range(CharacterData.HealthMinMax.x, CharacterData.HealthMinMax.y));
    }

    public void Move(Vector3 position)
    {
        Debug.Log("Moving");
    }
    public void Death()
    {
        Debug.Log("Dying");
    }

}
