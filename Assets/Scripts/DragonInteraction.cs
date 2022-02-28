using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonInteraction : MonoBehaviour
{
    public WanderingDragons control;

    private NavMeshAgent agent;
    public Animator anim;

    public GameObject interactPoint;

    public bool canInteract = false;
    public bool canInteract1 = false;

    public bool showOptions = false;
    public bool showOptions1 = false;

    public float cooldown;

    public bool d1 = false;
    public bool d2 = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(d1 == true)
        {
            cooldown += Time.deltaTime;

            if (cooldown >= 5)
            {
                control.enabled = true;
            }
        }

        if (d2 == true)
        {
            cooldown += Time.deltaTime;

            if (cooldown >= 5)
            {
                control.enabled = true;
            }
        }
    }

    private void OnMouseDown()
    {
        if(gameObject.tag == "Dragon1")
        {
            d1 = true;
            control.enabled = false;

            cooldown = 0;

            agent.SetDestination(interactPoint.transform.position);

            if(showOptions == false)
            {
                anim.SetInteger("choiceAnim", 0);
            }
        }

        if(gameObject.tag == "Dragon2")
        {
            d2 = true;
            control.enabled = false;

            cooldown = 0;
            cooldown += Time.deltaTime;

            if (cooldown >= 5)
            {
                control.enabled = true;
            }

            agent.SetDestination(interactPoint.transform.position);

            if (showOptions == false)
            {
                anim.SetInteger("choiceAnim", 0);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interact")
        {
            if (d1 == true)
            {
                showOptions = true;
            }

            if(d2 == true)
            {
                showOptions1 = true;
            }

            anim.SetInteger("choiceAnim", 1);
        }
    }
}
