using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimonSays : MonoBehaviour
{
    #region Singleton
    public static SimonSays instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of SimonSays found");
            return;
        }
        instance = this;
    }
    #endregion

    public ClickOnDragon[] dragons;

    public Text streakText;

    public float timeBetweenNotes;

    //this should be at 1 at the start of the game
    public int currentStreak = 1;

    public List<ClickOnDragon> clickOrder;
    public List<ClickOnDragon> playerOrder;
    public bool canClick;

    EventSystem eventSystem;


    int step = 0;


    void Start()
    {
        StartCoroutine(FlashButton());
    }

    IEnumerator FlashButton()
    {
        canClick = false;   
        yield return new WaitForSeconds(timeBetweenNotes);
        streakText.text = currentStreak.ToString();
        ClickOnDragon d = dragons[Random.Range(0, dragons.Length)];
        clickOrder.Add(d);
        for (int i = 0; i < currentStreak; i++)
        {
            clickOrder[i].GetComponent<Animator>().SetBool("Roar", true);

            yield return new WaitForSeconds(timeBetweenNotes);

            clickOrder[i].GetComponent<Animator>().SetBool("Roar", false);
            yield return new WaitForSeconds(0.5f);
        }
        canClick = true;
    }

    public void PressedDragon(int ID)
    {
        if (canClick)
        {
            ClickOnDragon d = dragons[ID];
            playerOrder.Add(d);

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
                    playerOrder.Clear();
                    StartCoroutine(FlashButton());
                }
            }
        }
        //d.GetComponent<Animator>().SetBool("Roar", false);

    }
}
