using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingMinigame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        SceneManager.LoadScene("TowerDefenseGame");
    }
}
