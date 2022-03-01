using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            TowerDefenseGameManager.instance.health -= 1;
            Destroy(other.gameObject);
        }
    }
}
