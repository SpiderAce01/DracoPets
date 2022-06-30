using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{
    public float timer;
    public float timer2;
    public float cooldown;

    public int rand;

    public bool timeUp = false;
    public bool started = false;
    public bool canPlay = true;
    public bool canPlayAgain = true;
    public bool canPlayAgainAgain = true;

    public Vector2 timeRange;

    public Text time;
    public Text gold;
    public Text reward;

    public GameObject stop;
    public GameObject startPanel;
    public GameObject endPanel;

    public MiniGameOne dragon;

    public AudioSource flying;
    public AudioSource timerAud;
    public AudioSource dragonAud;
    public AudioSource musicAud;
    public AudioSource windAud;
    public AudioSource startAud;
    public AudioSource endAud;
    public AudioSource stopAud;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(started == true)
        {
            timer -= Time.deltaTime;
            if (timeUp == false)
            {
                timer2 += Time.deltaTime;
            }
            time.text = Mathf.Round(timer).ToString();
            gold.text = "Gold: " + dragon.money.ToString();
            if(canPlay == true)
            {
                flying.Play();
                musicAud.Play();
                windAud.Play();
                dragonAud.Play();
                startAud.Pause();
                timerAud.PlayDelayed(0.2f);
                canPlay = false;
            }

            if (timer2 >= rand)
            {
                timer2 = 0;
                dragonAud.Play();
                rand = (int)Random.Range(timeRange.x, timeRange.y);
            }
        }

        if(timer <= 0)
        {
            timeUp = true;
        }

        if(timeUp == true)
        {
            time.gameObject.SetActive(false);
            stop.SetActive(true);

            if (canPlayAgainAgain == true)
            {
                stopAud.Play();
                canPlayAgainAgain = false;
            }

            cooldown -= Time.deltaTime;
            timerAud.Pause();

            if(cooldown <= 0)
            {
                endPanel.SetActive(true);

                if (canPlayAgain == true)
                {
                    endAud.Play();
                    windAud.Pause();
                    dragonAud.Pause();
                    flying.Pause();
                    canPlayAgain = false;
                }

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
