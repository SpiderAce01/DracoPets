using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject endPanel;

    public Text reward;
    public Text time;

    public bool started = false;

    public float timer;
    public int pieceCounter;
    public int puzzleCounter;
    public bool givenReward = false;
    public float moneyCounter = 200;

    void Start()
    {

    }

    private void Update()
    {
        if(started == true)
        {
            timer += Time.deltaTime;
            time.text = Mathf.Round(timer).ToString();
        }

        if (pieceCounter == 20)
        {
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
