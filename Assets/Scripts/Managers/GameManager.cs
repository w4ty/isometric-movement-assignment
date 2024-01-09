using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _allyCharacterAmount;
    private Vector3 _mapSize;
    public GameDataScriptableObject GameData;
    public Terrain BaseTerrain;
    public AllyCharacter Character;

    void CreateMap()
    {
        _mapSize = GameData.MapSize;
        BaseTerrain.enabled = true;
        BaseTerrain.terrainData.size = _mapSize;
    }
    void CreateCharacters()
    {
        _allyCharacterAmount = GameData.AllyCharacterAmount;
        Debug.Log("Creating characters");
    }
}
