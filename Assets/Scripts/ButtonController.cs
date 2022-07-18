using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject pieces1;
    public GameObject pieces2;

    public AudioSource timerAud;
    public AudioSource winAud;

    public Text reward;
    public Text time;

    public bool started = false;
    public bool canPlay = true;

    public float timer;
    public int pieceCounter;
    public int puzzleCounter;
    public int playing = 0;
    public bool givenReward = false;
    public float moneyCounter = 200;

    void Start()
    {

    }

    private void Update()
    {
        if(started == true)
        {
            if(canPlay == true)
            {
                timerAud.Play();
                canPlay = false;
            }
            timer += Time.deltaTime;
            time.text = Mathf.Round(timer).ToString();
        }

        if (pieceCounter == 20)
        {
            playing++;
            timerAud.Pause();

            if(playing == 1)
            {
                winAud.Play();
            }

            time.gameObject.SetActive(false);
            endPanel.SetActive(true);
            reward.text = "Congratulations! You won: " + Mathf.Round(moneyCounter).ToString();

            if(givenReward == false)
            {
                PlayerGold.instance.totalGold += (int)moneyCounter;
            }

            givenReward = true;
        }

        if(timer > 0 && pieceCounter != 20)
        {
            moneyCounter -= Time.deltaTime;
        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        started = true;
    }

    public void NextGame()
    {
        if(pieces1.activeInHierarchy == true)
        {
            pieceCounter = 0;
            playing = 0;
            pieces1.SetActive(false);
            endPanel.SetActive(false);
            timer = 0;
            pieces2.SetActive(true);
            time.gameObject.SetActive(true);
            givenReward = false;
        }
        else
        {
            PlayAgain();
        }
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
