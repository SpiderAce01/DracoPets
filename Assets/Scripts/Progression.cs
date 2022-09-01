using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour
{
    public Button minigame2, minigame3, minigame4;
    private void OnEnable()
    {
        if(DragonKeeper.instance.ownedDragons.Count >= 1)
        {
            minigame2.interactable = true;
        }

        if(DragonKeeper.instance.ownedDragons.Count >= 2)
        {
            minigame3.interactable = true;
        }

        if (DragonKeeper.instance.ownedDragons.Count >= 3)
        {
            minigame4.interactable = true;
        }
    }
}
