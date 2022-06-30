using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBehaviour : MonoBehaviour
{
    [SerializeField]
    public Transform destination;
    public float health = 1;
    public AudioSource die;

    private void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(destination.position);
        health += TowerDefenseGameManager.instance.timeElapsed / 100;
        die = GameObject.FindGameObjectWithTag("Die").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            die.Play();
            TowerDefenseGameManager.instance.kills += 1;
            Destroy(gameObject);
        }
    }
}
