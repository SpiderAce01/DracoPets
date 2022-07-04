using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimonSays : MonoBehaviour
{
    public Button[] buttons;

    public Text streakText;

    public float timeBetweenNotes;

    //this should be at 1 at the start of the game
    public int currentStreak = 1;

    public List<Button> clickOrder;
    public List<Button> playerOrder;

    EventSystem eventSystem;


    int step = 0;


    void Start()
    {
        StartCoroutine(FlashButton());
    }

    IEnumerator FlashButton()
    {
        yield return new WaitForSeconds(1);
        streakText.text = currentStreak.ToString();
        Button b = buttons[Random.Range(0, buttons.Length)];
        clickOrder.Add(b);
        for (int i = 0; i < currentStreak; i++)
        {
            clickOrder[i].GetComponent<AudioSource>().Play();

            clickOrder[i].interactable = false;

            //ColorBlock cb = clickOrder[i].colors;

            //cb.normalColor = Color.white;//clickOrder[i].colors.highlightedColor;
            //clickOrder[i].colors = cb;

            yield return new WaitForSeconds(timeBetweenNotes);
            clickOrder[i].interactable = true;
            //cb = clickOrder[i].colors;
            //cb.normalColor = clickOrder[i].colors.selectedColor;
            //clickOrder[i].colors = cb;

            yield return new WaitForSeconds(0.2f);
        }
        //ColorBlock cb2 = b.colors;
        //cb2.normalColor = b.colors.normalColor;
        //b.colors = cb2;

       // eventSystem.SetSelectedGameObject(null);
    }

    public void PressedButton()
    {
        Button b = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        playerOrder.Add(b);
        b.GetComponent<AudioSource>().Play();
        if (playerOrder[step] != clickOrder[step])        
        {
            clickOrder.Clear();
            playerOrder.Clear();
            step = 0;
            currentStreak = 1;
            StartCoroutine(FlashButton());            
        }
        else
        {
            step++;

            print(playerOrder.Count);
            if (playerOrder.Count == currentStreak)
            {
                step = 0;
                currentStreak++;
                //eventSystem.SetSelectedGameObject(null);
                //ColorBlock cb2 = b.colors;
                //cb2.normalColor = b.colors.selectedColor;
                // b.colors = cb2;
                playerOrder.Clear();
                StartCoroutine(FlashButton());
            }
        }
        
    }
}
