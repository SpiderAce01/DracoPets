using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{
    public float timer;
    public float cooldown;

    public bool timeUp = false;
    public bool started = false;

    public Text time;
    public Text gold;
    public Text reward;

    public GameObject stop;
    public GameObject startPanel;
    public GameObject endPanel;

    public MiniGameOne dragon;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(started == true)
        {
            timer -= Time.deltaTime;
            time.text = Mathf.Round(timer).ToString();
            gold.text = "Gold: " + dragon.money.ToString();
        }

        if(timer <= 0)
        {
            timeUp = true;
        }

        if(timeUp == true)
        {
            time.gameObject.SetActive(false);
            stop.SetActive(true);
            cooldown -= Time.deltaTime;

            if(cooldown <= 0)
            {
                endPanel.SetActive(true);
                reward.text = "Total gold collected: " + dragon.money.ToString();
            }
        }
    }

    public void StartGame()
    {
        started = true;
        startPanel.SetActive(false);
    }
    public void PlayAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("DemoScene");
    }
}
