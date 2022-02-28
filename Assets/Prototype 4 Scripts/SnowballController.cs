using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnowballController : MonoBehaviour
{
    public Rigidbody rb;
    public float turnSpeed = 3;
    public float gravityScale = -9.81f;
    public float sizeScale = 15;
    public float startTimer = 0;
    public int health = 3;
    public Text healthText;
    public Text distanceText;
    public Text finalDistance;
    public Button start;
    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject directionalLight;

    void Start()
    {
        Time.timeScale = 0;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f);
        rb.AddForce(movement * turnSpeed);
        Physics.gravity = new Vector3(0, gravityScale, 0);
        healthText.text = "Lives: " + health;

        distanceText.text = "Distance: " + Vector3.Distance(directionalLight.transform.position, transform.position).ToString("F2");


        if (health <= -1)
        {
            Time.timeScale = 0;
            endPanel.SetActive(true);
            finalDistance.text = "Distance Travelled: " + Vector3.Distance(directionalLight.transform.position, transform.position).ToString("F2");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Spawner")
        {
            Destroy(other.transform.parent.gameObject, 10);
            Scale();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstruction")
        {
            health--;
            if(gravityScale <= -9.81)
            {
                gravityScale *= 0.75f;
            }

            if(transform.localScale.x > 15)
            {
                sizeScale *= 0.75f;
                transform.localScale = new Vector3(sizeScale, sizeScale, sizeScale);
            }
        }
    }

    public void Scale()
    {
        if(gravityScale <= 70)
        {
            gravityScale -= 2;
        }
        
        if(transform.localScale.x <= 39)
        {
            sizeScale += 2;
            transform.localScale = new Vector3(sizeScale, sizeScale, sizeScale);
        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Prototype 3", LoadSceneMode.Single);
    }
}
