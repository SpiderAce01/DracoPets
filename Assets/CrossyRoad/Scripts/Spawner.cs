using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("required componants")]
    public GameObject carPrefab;
    public GameObject[] carModels;
    [Header("Stats")]
    public float spawnRate;

    public bool flipped = false;

    private void Start()
    {
        spawnRate = Random.Range(75, 150);
    }


    public void SpawnCar()
    {
        GameObject car = Instantiate(carPrefab,transform);
        car.transform.parent = transform;
        car.transform.localScale = new Vector3(1, 4, 0.1f);

        car.GetComponent<Car>().PickModel(carModels);
        car.GetComponent<Car>().speed = Random.Range(5f, 10f);
        if (flipped)
        {
            car.GetComponent<Car>().speed = -car.GetComponent<Car>().speed;
        }

    }
    float count = 0;
    private void FixedUpdate()
    {
        count += 1;
        if(count >= spawnRate)
        {
            count = 0;
            SpawnCar();
        }
    }
}
