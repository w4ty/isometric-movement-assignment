using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _allyCharacterAmount;
    private Vector3 _mapSize;
    public Terrain BaseTerrain;
    public AllyCharacter Character;

    void CreateMap()
    {
        BaseTerrain.enabled = true;
        BaseTerrain.terrainData.size = _mapSize;
    }
    void CreateCharacters()
    {
        Debug.Log("Creating characters");
    }
}
