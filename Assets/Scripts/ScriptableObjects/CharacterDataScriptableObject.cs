using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterDataScriptableObject", order = 1)]
public class CharacterDataScriptableObject : ScriptableObject
{
    public Vector2 SpeedMinMax = new Vector2(1, 3);
    public Vector2 AgilityMinMax = new Vector2(1, 3);
    public Vector2 HealthMinMax = new Vector2(100, 150);
}
