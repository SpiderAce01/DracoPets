using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Required componants")]
    public GameObject gameLevel;
    [Header("STATS")]
    public float speed;
    public Vector2 bounds;
    Vector2 inputs;

    private void Update()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //moves the map back and forth
        gameLevel.transform.position += new Vector3(0, 0, -inputs.y * speed * Time.deltaTime);
        //moves player left and right
        if(transform.position.x + inputs.x > bounds.x && transform.position.x + inputs.x < bounds.y)
        {
            transform.position += new Vector3(inputs.x * speed * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            print("GAME OVER");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            print("GAME OVER");
            UI.instance.deathScreen.SetActive(true);
            UI.instance.distanceTXT.text = ProgressTracker.instance.distance.ToString() + "m";
            Time.timeScale = 0;
        }
    }
}
