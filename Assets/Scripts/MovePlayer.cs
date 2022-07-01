using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    public float maxFuel;
    public float currentFuel;
    public Slider fuelSlider;
    public float fuelFromPickup;

    bool isTurning = false;

    public bool canDie;
    public GameObject deathPanel;
    public Text deathMessage;
    public Text finalScore;
    public Text highScoreText;

    Rigidbody rb;

    void Start()
    {
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
        else
        {
        }
        currentFuel = maxFuel;

        fuelSlider.maxValue = maxFuel;

        InvokeRepeating("RemoveFuel", 1, 1);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void Update()
    {
        Cursor.visible = deathPanel.active;

        fuelSlider.value = currentFuel;

        if(currentFuel <= 0)
        {
            Death(false);
        }

        if (deathPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        if (rb.velocity.z > speed)
        {
            Vector3 vel = rb.velocity;
            vel.z = speed;
            rb.velocity = vel;
        }
        ProcessInputs();
    }

    private void ProcessInputs()
    {

        Vector3 vel = rb.velocity;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, -vel.x);

        if (Input.GetKey(KeyCode.A) && vel.x > -45)
        {
            isTurning = true;
            rb.AddForce(-transform.right * turnSpeed, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.D) && vel.x < 45)
        {
            isTurning = true;
            rb.AddForce(transform.right * turnSpeed, ForceMode.VelocityChange);
        }

        if (isTurning == false)
        {
            // rb.AddForce(transform.forward * turnSpeed, ForceMode.VelocityChange);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isTurning = false;
        }
    }

    void RemoveFuel()
    {
        if(deathPanel.active == false)
        currentFuel -= 1;
    }

    void Death(bool crashed)
    {

        PlayerPrefs.SetInt("score", ScoreTracker.instance.score);
        if (PlayerPrefs.GetInt("score") >  PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", ScoreTracker.instance.score);

        }

        deathPanel.SetActive(true);
        if (crashed)
            deathMessage.text = "CRASHED";
        else
            deathMessage.text = "OUT OF FUEL";

        finalScore.text = ScoreTracker.instance.score.ToString() + " M";
        highScoreText.text = PlayerPrefs.GetInt("highscore") + " M";
        rb.velocity = Vector3.zero;
    }

    void AddFuel()
    {
        GetComponent<AudioSource>().Play();
        currentFuel += fuelFromPickup;

        if (currentFuel > maxFuel)
            currentFuel = maxFuel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle" && canDie)
        {
            Death(true);
        }

        if(other.tag == "Fuel")
        {
            AddFuel();
        }
    }
}
