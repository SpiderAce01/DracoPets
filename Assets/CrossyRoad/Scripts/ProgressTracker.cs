using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public static ProgressTracker instance;

    public float distance;

    private void Start()
    {
        instance = this;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Tile Number " + transform.localPosition.z / 5);
            distance = transform.localPosition.z / 5;
            transform.position += new Vector3(0, 0, 5);
            LevelCreator.instance.SpawnNewTile(LevelCreator.instance.tileTypes[Random.Range(0, LevelCreator.instance.tileTypes.Length)]);
        }
    }
}
