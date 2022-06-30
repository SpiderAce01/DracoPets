using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject dragon1;
    public GameObject dragon2;
    public GameObject dragon3;
    public GameObject spawnPoint;

    public Text d1;
    public Text d2;
    public Text d3;

    public PlayerGold gold;

    public AudioSource buyDragons;

    void Start()
    {
        
    }

    void Update()
    {
        gold = PlayerGold.instance;
    }

    public void BuyDragon1()
    {
        if(gold.totalGold >= 100)
        {
            buyDragons.Play();
            Instantiate(dragon1, spawnPoint.transform.position, spawnPoint.transform.rotation);
            gold.totalGold -= 100;
            d1.text = "SOLD";
            d1.transform.parent.GetComponent<Button>().interactable = false;
        }
    }

    public void BuyDragon2()
    {
        if (gold.totalGold >= 200)
        {
            buyDragons.Play();
            Instantiate(dragon2, spawnPoint.transform.position, spawnPoint.transform.rotation);
            gold.totalGold -= 200;
            d2.text = "SOLD";
            d2.transform.parent.GetComponent<Button>().interactable = false;
        }
    }

    public void BuyDragon3()
    {
        if (gold.totalGold >= 300)
        {
            buyDragons.Play();
            Instantiate(dragon3, spawnPoint.transform.position, spawnPoint.transform.rotation);
            gold.totalGold -= 300;
            d3.text = "SOLD";
            d3.transform.parent.GetComponent<Button>().interactable = false;
        }
    }
}
