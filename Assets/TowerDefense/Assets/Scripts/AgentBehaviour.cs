using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBehaviour : MonoBehaviour
{
    [SerializeField]
    public Transform destination;
    public float health = 1;

    private void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(destination.position);
        health += TowerDefenseGameManager.instance.timeElapsed / 100;
    }

    private void Update()
    {
        if (health <= 0)
        {
            TowerDefenseGameManager.instance.kills += 1;
            Destroy(gameObject);
        }
    }
}
