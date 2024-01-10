using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    private int _allyCharacterAmount;
    private Vector3 _mapSize;
    public GameDataScriptableObject GameData;
    public Terrain BaseTerrain;
    public AllyCharacter Character;

    private void OnExited()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    void Awake()
    {
        CreateMap();
        if (inputManager != null)
        {
            inputManager.OnExited += OnExited;
        }
    }

    private void OnDestroy()
    {
        if (inputManager != null) 
        {
            inputManager.OnExited -= OnExited;
        }
    }

    void CreateMap()
    {
        _mapSize = GameData.MapSize;
        BaseTerrain.gameObject.SetActive(true);
        BaseTerrain.terrainData.size = _mapSize;
    }
    void CreateCharacters()
    {
        _allyCharacterAmount = GameData.AllyCharacterAmount;
        Debug.Log("Creating characters");
    }
}
