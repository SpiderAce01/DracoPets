using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyableItem : MonoBehaviour
{
    public GameObject item;
    public float price;

    public Text priceTXT;

    public void BuyItem()
    {
        if(TowerDefenseGameManager.instance.money >= price)
        {
            
            PurchaseManager.instance.BuyItem(item, price);
            price = price * 2;
        }
        else
        {
            print("Can't afford");
        }
    }

    private void Update()
    {
        priceTXT.text = "$" + price.ToString();
    }
}
