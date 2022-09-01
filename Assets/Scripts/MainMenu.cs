using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject quitPanel;

    public void Quit()
    {
        Application.Quit();
    }

    public void SwapScene(string sceneToSwapTo)
    {
        SceneManager.LoadScene(sceneToSwapTo);
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    public void BeginQuit()
    {
        quitPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CancelQuit()
    {
        quitPanel.SetActive(false);
        Time.timeScale = 1;
    }
}