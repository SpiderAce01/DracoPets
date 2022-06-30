using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingDragons : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    public int animRand;
    private int audCheck;

    public bool canChoose = true;
    public bool canPlay = true;
    public bool canWalk = true;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public Animator anim;

    public AudioSource aud;

    public AudioClip eating;
    public AudioClip roar;
    public AudioClip walk;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

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
            canWalk = true;
        }
        else
        {
            anim.SetInteger("choiceAnim", 0);

            if (canWalk == true)
            {
                aud.loop = true;
                aud.clip = walk;
                aud.volume = 0.2f;
                aud.Play();
                canWalk = false;
            }

            canChoose = true;
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
        audCheck++;

        if(audCheck >= 4)
        {
            print("work");

            if (canChoose == true)
            {
                animRand = Random.Range(1, 4);
                canChoose = false;
                canPlay = true;
            }

            switch (animRand)
            {
                case 1:
                    wanderTimer = 7;
                    anim.SetInteger("choiceAnim", 1);
                    aud.clip = null;
                    break;
                case 2:
                    wanderTimer = 4;
                    anim.SetInteger("choiceAnim", 2);
                    if (canPlay == true)
                    {
                        canPlay = false;
                        aud.clip = roar;
                        aud.loop = false;
                        aud.volume = 1;
                        aud.PlayDelayed(0.75f);
                    }
                    break;
                case 3:
                    wanderTimer = 5;
                    anim.SetInteger("choiceAnim", 3);
                    if (canPlay == true)
                    {
                        canPlay = false;
                        aud.clip = eating;
                        aud.loop = false;
                        aud.volume = 0.3f;
                        aud.Play();
                    }
                    break;
            }
        }
    }
}
