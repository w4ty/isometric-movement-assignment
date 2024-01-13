using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameDataScriptableObject", order = 1)]
public class GameDataScriptableObject : ScriptableObject
{
    public Vector3Int MapSize = new Vector3Int(50, 600, 50);
    public List<SpawnerInfo> Spawns = new List<SpawnerInfo>();
}
