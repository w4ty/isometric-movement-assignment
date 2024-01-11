using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameDataScriptableObject", order = 1)]
public class GameDataScriptableObject : ScriptableObject
{
    public List<Vector3> AllyCharacters = new List<Vector3>();
    public Vector3 MapSize = new Vector3(50, 50, 600);
}
