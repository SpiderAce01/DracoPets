using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public static LevelCreator instance;
    public GameObject[] tileTypes;
    public List<GameObject> tilesInScene;
    GameObject lastSpawnedTile;

    private void Start()
    {
        instance = this;
        lastSpawnedTile = gameObject;
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
        SpawnNewTile(tileTypes[Random.Range(0, tileTypes.Length)]);
    }


    public void SpawnNewTile(GameObject type)
    {
        GameObject newTile = Instantiate(type, transform);
        newTile.transform.localPosition = new Vector3(0, 0, lastSpawnedTile.transform.localPosition.z + 5);
        tilesInScene.Add(newTile);
        lastSpawnedTile = newTile;
    }

    public void DeleteOldTiles(GameObject currentTile)
    {
        foreach(GameObject tile in tilesInScene)
        {
            if(tile.transform.position.z < currentTile.transform.position.z)
            {
                Destroy(tile);
            }
        }
        tilesInScene.TrimExcess();
    }
}
