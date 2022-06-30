using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector]
    public GameObject target;
    public GameObject projectilePrefab;
    public float damage = 1;
    [Range(0.1f,3f)]public float fireRate;

    public AudioSource shoot;

    float count;
    //change later to an on trigger stay with more complexity for targeting many within range
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && target == null)
        {
            count = fireRate;
            target = other.gameObject;
        }
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            //Debug.Log(Vector3.Distance(target.transform.position, transform.position));
            Vector3 targetDirection = target.transform.position - gameObject.transform.position;
            Quaternion rotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = rotation;
            count += 1 * Time.deltaTime;
            if (count >= fireRate)
            {
                //shoot.Play();
                GameObject firedProjectile = Instantiate(projectilePrefab, transform);
                firedProjectile.GetComponent<Projectile>().target = target;
                firedProjectile.GetComponent<Projectile>().damage = damage;
                count = 0;
            }


            if (Vector3.Distance(target.transform.position, transform.position) > GetComponent<SphereCollider>().radius * 2)
            {
                target = null;
            }
        }
    }
}
