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

    public AudioSource horn;
    public AudioSource traffic;
    public AudioSource crash;
    public AudioSource frog;
    public AudioSource wing;
    public AudioSource music;
    public AudioSource musicEnd;
    public Vector2 timeRange;
    public float timer;
    public float timer2;
    public int rand;
    public int rand2;
    public bool canPlay = true;

    private void Start()
    {
        rand = (int)Random.Range(timeRange.x, timeRange.y);
    }

    private void Update()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Vertical");
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if(timer >= rand)
        {
            timer = 0;
            horn.pitch = Random.Range(0.7f, 1.2f);
            horn.Play();
            rand = (int)Random.Range(timeRange.x, timeRange.y);
        }

        if (timer2 >= rand2)
        {
            timer2 = 0;
            frog.Play();
            rand2 = (int)Random.Range(timeRange.x, timeRange.y);
        }
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
            if(canPlay == true)
            {
                crash.Play();
                wing.Pause();
                music.Pause();
                musicEnd.Play();
                traffic.Pause();
                canPlay = false;
            }
            print("GAME OVER");
            UI.instance.deathScreen.SetActive(true);
            UI.instance.distanceTXT.text = ProgressTracker.instance.distance.ToString() + "m";
            Time.timeScale = 0;
        }
    }
}
