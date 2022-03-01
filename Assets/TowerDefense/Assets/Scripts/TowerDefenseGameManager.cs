using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TowerDefenseGameManager : MonoBehaviour
{
    public static TowerDefenseGameManager instance;

    public float timeElapsed;

    public float health = 100;
    public Text healthTXT;
    public float money;
    public Text moneyTXT;
    public float kills;
    public Text killsTXT;

    public GameObject gameOverScreen;


    private void Start()
    {
        Time.timeScale = 1;
        instance = this;
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        moneyTXT.text = "$" + money.ToString();
        healthTXT.text = health.ToString();
        if(health <= 0)
        {
            print("GAME OVER");
            gameOverScreen.SetActive(true);
            killsTXT.text = kills.ToString();
            Time.timeScale = 0;
        }
    }

    private void FixedUpdate()
    {
        timeElapsed += 1 * Time.deltaTime;
    }

    public void Retry()
    {
        //CHANGE WHEN YOU MERGE 
        SceneManager.LoadScene("TowerDefenseGame");
    }
    public void BackToLobby()
    {
        SceneManager.LoadScene("DemoScene");
    }
}
