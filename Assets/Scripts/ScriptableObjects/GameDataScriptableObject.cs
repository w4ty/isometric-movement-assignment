using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameDataScriptableObject", order = 1)]
public class GameDataScriptableObject : ScriptableObject
{
    public int AllyCharacterAmount = 3;
    public Vector3 MapSize = new Vector3(50, 50, 600);
}
