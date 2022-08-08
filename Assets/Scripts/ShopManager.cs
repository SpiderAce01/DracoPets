using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject dragon0;
    public GameObject dragon1;
    public GameObject dragon2;
    public GameObject dragon3;
    public GameObject spawnPoint;

    public Text d1;
    public Text d2;
    public Text d3;

    public PlayerGold gold;

    public AudioSource buyDragons;

    public static ShopManager instance;

    public GameObject[] shops;
    public GameObject[] foodPrefabs;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        gold = PlayerGold.instance;
    }

    public void BuyDragon()
    {
        if(gold.totalGold >= 100)
        {
            buyDragons.Play();
            Instantiate(dragon1, spawnPoint.transform.position, spawnPoint.transform.rotation);
            gold.totalGold -= 100;
            d1.text = "SOLD";
            d1.transform.parent.GetComponent<Button>().interactable = false;
            DragonKeeper.instance.dragon1 = dragon1;
            this.gameObject.SetActive(false);
        }
    }

    public void BuyDragon1()
    {
        if (gold.totalGold >= 200)
        {
            buyDragons.Play();
            Instantiate(dragon2, spawnPoint.transform.position, spawnPoint.transform.rotation);
            gold.totalGold -= 200;
            d2.text = "SOLD";
            d2.transform.parent.GetComponent<Button>().interactable = false;
            DragonKeeper.instance.dragon2 = dragon2;
            this.gameObject.SetActive(false);
        }
    }

    public void BuyDragon2()
    {
        if (gold.totalGold >= 300)
        {
            buyDragons.Play();
            Instantiate(dragon3, spawnPoint.transform.position, spawnPoint.transform.rotation);
            gold.totalGold -= 300;
            d3.text = "SOLD";
            d3.transform.parent.GetComponent<Button>().interactable = false;
            DragonKeeper.instance.dragon3 = dragon3;
            this.gameObject.SetActive(false);
        }
    }

    public void ChangeShop(int id)
    {
        for (int i = 0; i < shops.Length; i++)
        {
            shops[i].SetActive(false);
        }

        shops[id].SetActive(true);
    }

    public void BuyFood(GameObject prefab)
    {
        if(gold.totalGold >= prefab.GetComponent<FoodPiece>().cost)
        {
            buyDragons.Play();
            gold.totalGold -= prefab.GetComponent<FoodPiece>().cost;
            Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            this.gameObject.SetActive(false);
        }
    }
}
