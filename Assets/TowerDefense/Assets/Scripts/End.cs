using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public AudioSource healthAud;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            healthAud.Play();
            TowerDefenseGameManager.instance.health -= 1;
            Destroy(other.gameObject);
        }
    }
}
