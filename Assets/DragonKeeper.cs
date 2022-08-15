using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonKeeper : MonoBehaviour
{
    public List <GameObject> ownedDragons;

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

            foreach (GameObject dragon in ownedDragons)
            {
                Instantiate(dragon, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
        }
    }
}
