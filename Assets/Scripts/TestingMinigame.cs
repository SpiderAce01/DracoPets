using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingMinigame : MonoBehaviour
{
    public GameObject mGPanel;
    public GameObject sPanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Testing()
    {
        SceneManager.LoadScene("MiniGame1");
    }

    public void Testing1()
    {
        SceneManager.LoadScene("MiniGame2");
    }
    public void Testing2()
    {
        SceneManager.LoadScene("Runner Game");
    }
    public void Testing3()
    {
        SceneManager.LoadScene("CrossyRoad");
    }

    public void MiniGamePanel()
    {
        mGPanel.SetActive(true);
    }

    public void MGClose()
    {
        mGPanel.SetActive(false);
    }

    public void ShopPanel()
    {
        sPanel.SetActive(true);
    }

    public void SClose()
    {
        sPanel.SetActive(false);
    }
}
