using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    private List<Vector3> allyCharacters;
    private Vector3 mapSize;
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
        CreateCharacters();
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
        mapSize = GameData.MapSize;
        BaseTerrain.gameObject.SetActive(true);
        BaseTerrain.terrainData.size = mapSize;
    }
    void CreateCharacters()
    {
        allyCharacters = GameData.AllyCharacters;
        for (int i = 0;  i < allyCharacters.Count; i++)
        {
            Instantiate(Character).transform.position = allyCharacters[i];
        }
    }
}
