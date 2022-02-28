using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public DragonInteraction dBool;
    public DragonInteraction dBool1;

    public GameObject button;
    public GameObject button1;
    public GameObject back;
    public GameObject back1;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (dBool.showOptions == true)
        {
            ButtonReset();
            button.SetActive(true);
            back.SetActive(true);
        }

        if (dBool1.showOptions1 == true)
        {
            print("2working");
            ButtonReset();
            button1.SetActive(true);
            back1.SetActive(true);
        }
    }

    public void ButtonReset()
    {
        button.SetActive(false);
        button1.SetActive(false);
        back.SetActive(false);
        back1.SetActive(false);
    }

    

    public void BackToWander()
    {
        ButtonReset();
        dBool.control.enabled = true;
        dBool.canInteract = false;
        dBool.showOptions = false;
    }

    public void BackToWander1()
    {
        ButtonReset();
        dBool1.control.enabled = true;
        dBool1.canInteract1 = false;
        dBool1.showOptions = false;
    }
}
