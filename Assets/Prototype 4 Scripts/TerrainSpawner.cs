using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject[] pathPieces;
    public Transform spawnPoint;
    public SnowballController sb;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            int ran = Random.Range(0, pathPieces.Length - 1);
            Instantiate(pathPieces[ran], spawnPoint.position, spawnPoint.rotation);
            sb.Scale();
        }
    }
}
