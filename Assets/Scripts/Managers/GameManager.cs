using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private AllyManager allyManager;
    [SerializeField]
    private UIManager uiManager;
    private List<SpawnerInfo> spawns = new();
    private Vector3Int mapSize;
    public GameDataScriptableObject GameData;
    public Terrain BaseTerrain;

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
        SpawnObjects();
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
        BaseTerrain.gameObject.transform.position = Vector3Int.zero;
        BaseTerrain.terrainData.size = mapSize;
    }
    void SpawnObjects()
    {
        spawns.AddRange(GameData.Spawns);
        for (int i = 0;  i < spawns.Count; i++)
        {
            var instance = Instantiate(spawns[i].SpawnObject);
            instance.transform.position = spawns[i].Position;
            instance.transform.rotation = spawns[i].Rotation;
            if (instance.TryGetComponent(out AllyCharacter ally))
            {
                allyManager.Allies.Add(ally);
                uiManager.CreateButton($"Character {allyManager.Allies.Count}", ally);
            }
        }
        spawns.Clear();
    }
}
