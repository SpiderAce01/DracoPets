using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public PlayerGold gold;

    void Start()
    {

        gold = PlayerGold.instance;
        gameObject.GetComponent<Text>().text = gold.totalGold.ToString();
    }

    void Update()
    {
        gameObject.GetComponent<Text>().text = gold.totalGold.ToString();
    }
}
