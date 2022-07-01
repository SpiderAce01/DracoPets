using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewTerrain : MonoBehaviour
{

    public GameObject terrainPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spawn Forward")
        {
            Instantiate(terrainPrefab, new Vector3(0, 0, (int)other.transform.position.z + 500), Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Delete")
        {
            Destroy(other.transform.root.gameObject);
        }
    }
}
