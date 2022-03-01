using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    [Range(0.1f, 1.5f)]
    public float coolDown;


    float count = 0;

    private void FixedUpdate()
    {
        count += 1 * Time.deltaTime;

        if (count >= coolDown)
        {
            count = 0;
            Instantiate(enemyToSpawn, transform, false);
            coolDown -= 0.1f * Time.deltaTime;
        }
    }

}
