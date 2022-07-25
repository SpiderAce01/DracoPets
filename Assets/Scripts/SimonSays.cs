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
    public Text goldEarnedText;

    int goldEarned;

    public float timeBetweenNotes;

    //this should be at 1 at the start of the game
    public int currentStreak = 1;

    public List<ClickOnDragon> clickOrder;
    public List<ClickOnDragon> playerOrder;
    public bool canClick;

    public GameObject instructionsPanel;

    public AudioClip dingSound, errSound;

    EventSystem eventSystem;


    int step = 0;


    void Start()
    {
        instructionsPanel.SetActive(true);
    }

    IEnumerator FlashButton(int soundToPlay)
    {
        canClick = false;   
        yield return new WaitForSeconds(timeBetweenNotes);
        if (soundToPlay == 1)
        {
            GetComponent<AudioSource>().clip = dingSound;
            GetComponent<AudioSource>().Play();
        }
        if (soundToPlay == 2)
        {
            GetComponent<AudioSource>().clip = errSound;
            GetComponent<AudioSource>().Play();
        }
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
                StartCoroutine(FlashButton(2));
            }
            else
            {
                step++;
                
                if (playerOrder.Count == currentStreak)
                {
                    step = 0;
                    currentStreak++;
                    playerOrder.Clear();
                    if(PlayerGold.instance != null)
                    PlayerGold.instance.totalGold += 1;
                    goldEarned += 1;
                    goldEarnedText.text = "Gold Earned: " + goldEarned;
                    StartCoroutine(FlashButton(1));
                }
            }
        }
        //d.GetComponent<Animator>().SetBool("Roar", false);

    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
        StartCoroutine(FlashButton(0));
    }
}
