using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnDragon : MonoBehaviour
{
    public int ID;
    private void OnMouseDown()
    {
        if (SimonSays.instance.canClick)
        {
            SimonSays.instance.PressedDragon(ID);
            GetComponent<Animator>().SetBool("Roar", true);
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForEndOfFrame();
        GetComponent<Animator>().SetBool("Roar", false);
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
