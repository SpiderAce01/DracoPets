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
        //this is wrong, it needs to keep the order, and add a new one onto it each time
        yield return new WaitForSeconds(1);
       // clickOrder.Clear();
        streakText.text = currentStreak.ToString();
        for (int i = 0; i < currentStreak; i++)
        {
            Button b = buttons[Random.Range(0, buttons.Length)];
            clickOrder.Add(b);

            b.GetComponent<AudioSource>().Play();
            ColorBlock cb = b.colors;
            cb.normalColor = b.colors.highlightedColor;
            b.colors = cb;

            yield return new WaitForSeconds(timeBetweenNotes);
            ColorBlock cb2 = b.colors;
            cb2.normalColor = b.colors.selectedColor;
            b.colors = cb2;
        }
    }

    public void PressedButton()
    {
        Button b = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        playerOrder.Add(b);
        b.GetComponent<AudioSource>().Play();
        if (playerOrder[step] != clickOrder[step])        
        {
            print("WRONG");
        }
        step++;

        if(playerOrder.Capacity == clickOrder.Capacity)
        {
            step = 0;
            currentStreak++;
            //eventSystem.SetSelectedGameObject(null);
            ColorBlock cb2 = b.colors;
            cb2.normalColor = b.colors.selectedColor;
            b.colors = cb2;
            playerOrder.Clear();
            StartCoroutine(FlashButton());
        }
    }
}
