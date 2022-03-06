using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
    }

    public void PickModel(GameObject[] models)
    {
        GameObject model = models[Random.Range(0, models.Length)];
        GameObject childObject = Instantiate(model, transform);
        childObject.transform.parent = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Car")
        {
            if(other.gameObject.GetComponent<Car>().speed < speed)
            {
                speed = other.gameObject.GetComponent<Car>().speed;
            }
        }
    }
}
