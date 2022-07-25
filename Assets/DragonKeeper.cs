using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonKeeper : MonoBehaviour
{
    public GameObject dragon1;
    public GameObject dragon2;
    public GameObject dragon3;

    public GameObject spawnPoint;

    public static DragonKeeper instance;
    
    void Start()
    {
        //instance = this;
        DontDestroyOnLoad(this.gameObject);


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {

            spawnPoint = GameObject.FindGameObjectWithTag("Interact");
            if(dragon1 != null)
            {
               //ShopManager.instance.d1.text = "SOLD";
                //ShopManager.instance.d1.transform.parent.GetComponent<Button>().interactable = false;
                Instantiate(dragon1, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }

            if (dragon2 != null)
            {
                //ShopManager.instance.d2.text = "SOLD";
                //ShopManager.instance.d2.transform.parent.GetComponent<Button>().interactable = false;
                Instantiate(dragon2, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }

            if (dragon3 != null)
            {
                //ShopManager.instance.d3.text = "SOLD";
                //ShopManager.instance.d3.transform.parent.GetComponent<Button>().interactable = false;
                Instantiate(dragon3, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
        }
    }
}
