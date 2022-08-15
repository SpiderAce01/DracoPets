using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject[] dragons;
    public GameObject selectedDragon;
    public GameObject spawnPoint;

    public Text d1;
    public Text d2;
    public Text d3;

    public GameObject infoPanel;
    public Text nameText, infoText;
    public Button buyButton;

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

    private void OnEnable()
    {
        if (DragonKeeper.instance.ownedDragons.Contains(dragons[1]))
        {
            d1.text = "SOLD";
        }

        if (DragonKeeper.instance.ownedDragons.Contains(dragons[2]))
        {
            d2.text = "SOLD";
        }

        if (DragonKeeper.instance.ownedDragons.Contains(dragons[3]))
        {
            d3.text = "SOLD";
        }
    }

    private void OnDisable()
    {
        infoPanel.SetActive(false);
    }

    public void ShowDragonInfo(int id)
    {
        infoPanel.SetActive(true);
        nameText.text = dragons[id].name;
        infoText.text = dragons[id].GetComponent<WanderingDragons>().info;        
        selectedDragon = dragons[id];
        if (DragonKeeper.instance.ownedDragons.Contains(selectedDragon) || selectedDragon == dragons[0])
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
    }

    public void BuyDragon()
    {
        if (gold.totalGold >= selectedDragon.GetComponent<WanderingDragons>().cost)
        {
            buyDragons.Play();
            Instantiate(selectedDragon, spawnPoint.transform.position, spawnPoint.transform.rotation);
            gold.totalGold -= selectedDragon.GetComponent<WanderingDragons>().cost;
            DragonKeeper.instance.ownedDragons.Add(selectedDragon);
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
        if (gold.totalGold >= prefab.GetComponent<FoodPiece>().cost)
        {
            buyDragons.Play();
            gold.totalGold -= prefab.GetComponent<FoodPiece>().cost;
            Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            this.gameObject.SetActive(false);
        }
    }
}
