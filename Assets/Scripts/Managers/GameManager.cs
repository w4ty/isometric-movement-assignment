using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    private List<SpawnerInfo> spawns;
    private Vector3 mapSize;
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
        BaseTerrain.terrainData.size = mapSize;
    }
    void SpawnObjects()
    {
        spawns = GameData.Spawns;
        for (int i = 0;  i < spawns.Count; i++)
        {
            Instantiate(spawns[i].SpawnObject).transform.position = spawns[i].Position;
        }
        spawns.Clear();
    }
}
