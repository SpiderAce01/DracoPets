using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingDragons : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    public int animRand;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public Animator anim;

    // Use this for initialization
    void OnEnable()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        if ((Mathf.Approximately(agent.velocity.x, 0) && Mathf.Approximately(agent.velocity.y, 0) && Mathf.Approximately(agent.velocity.z, 0)))
        {
            AnimationController();
        }
        else
        {
            anim.SetInteger("choiceAnim", 0);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void AnimationController()
    {
        animRand = Random.Range(1, 4);

        switch (animRand)
        {
            case 1:
                wanderTimer = 10;
                anim.SetInteger("choiceAnim", 1);
                break;
            case 2:
                wanderTimer = 20;
                anim.SetInteger("choiceAnim", 2);
                break;
            case 3:
                wanderTimer = 10;
                anim.SetInteger("choiceAnim", 3);
                break;
        }
    }
}
