using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instance;
    public GameObject deathScreen;

    public Text distanceTXT;

    private void Start()
    {
        instance = this;
        Time.timeScale = 1;
        deathScreen.SetActive(false);
    }

    public void Replay()
    {
        SceneManager.LoadScene("CrossyRoad");
    }
    public void BackToDragons()
    {
        SceneManager.LoadScene("DemoScene");
    }
}
