using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeTile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("CLEAN UP");
            LevelCreator.instance.DeleteOldTiles(gameObject);
        }
    }
}
