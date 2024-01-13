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
        GridLogic();
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
            if (instance.TryGetComponent(out AllyCharacter ally))
            {
                uiManager.CreateButton(ally.ToString(), ally);
                allyManager.Allies.Add(ally);
            }
        }
        spawns.Clear();
    }

    private void GridLogic()
    {
        GetComponent<PathGrid>().SetGrid(mapSize.x, mapSize.z);
    }
}
