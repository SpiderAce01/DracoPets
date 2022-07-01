using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacles : MonoBehaviour
{
    public bool moveToCenter;
    [Tooltip("A hardcoded amount of objects in the scene")]
    public int obstacleAmount = 25; //How many obstacles do we spawn?
    public Vector2 obstacleSizeRange;
    [Tooltip("If selected, set a minimum and maximum amount of obstacles and it will choose a random amount each time")]
    public bool randomAmount = false;
    public int minAmount;
    public int maxAmount;
    public bool randomRotate;
    [Tooltip("Add more elements and drop obstacles prefabs into this array")]
    public GameObject[] prefabPool; //Obstacle Prefabs go here

    public Vector3 centre; // These control where the obstacles can spawn
    public Vector3 size; // Big Cube, can have multiple cubes for odd shaped terrain

    private void Start()
    {
        if(moveToCenter)
        centre = new Vector3(transform.localPosition.x + 500, -0.5f,transform.localPosition.z + 500);

        if (randomAmount)
        {
            obstacleAmount = Random.Range(minAmount, maxAmount);
        }
        Spawn();
    }

    public void RandomPosition()
    {
        Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), 1, Random.Range(-size.z / 2, size.z / 2)); // Randomize position within the cube
    }

    public void Spawn()
    {
        for (int i = 0; i <= obstacleAmount; i++) // Keeps spawning until the specified amount of garbage is reached
        {
            Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), 1, Random.Range(-size.z / 2, size.z / 2)); // Randomize position within the cube

            Quaternion rot;
            if (randomRotate)
                rot = Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
            else
                rot = Quaternion.identity;

            int garbageNumber = Random.Range(0, (prefabPool.Length)); // Random piece of garbage from the array
            GameObject obs = Instantiate(prefabPool[garbageNumber], pos, rot,this.transform);
            obs.transform.localScale *= Random.Range(obstacleSizeRange.x, obstacleSizeRange.y);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f); // Fancy visual indicator go brr
        Gizmos.DrawCube(centre, size);
    }
}