using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PurchaseManager : MonoBehaviour
{
    public static PurchaseManager instance;
    public GameObject displayObject;
    public AudioSource placeAud;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if(displayObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //print(hit.point);
                if(hit.collider.gameObject != displayObject)
                {
                    displayObject.transform.position = hit.point;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    placeAud.Play();
                    ConstructItem();
                }
            }
        }
    }

    public void BuyItem(GameObject item, float price)
    {
        TowerDefenseGameManager.instance.money -= price;
        price = price * 2;
        displayObject = Instantiate(item);
        displayObject.transform.parent = null;

        displayObject.GetComponent<Tower>().enabled = false;
    }
    public void ConstructItem()
    {
        displayObject.GetComponent<Tower>().enabled = true;
        displayObject = null;

    }




}
