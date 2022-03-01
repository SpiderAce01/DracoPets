using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public float lifeSpan = 1;
    [HideInInspector]
    public GameObject target;

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }
    }


    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        lifeSpan -= 1 * Time.deltaTime;
        if (lifeSpan <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            print("HIT!");
            TowerDefenseGameManager.instance.money += 1;
            other.gameObject.GetComponent<AgentBehaviour>().health -= damage;
            Destroy(gameObject);
        }
    }
}
