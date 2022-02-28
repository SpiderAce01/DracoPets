using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameOne : MonoBehaviour
{
    public GameObject dragon;
    public float speed;
    public float lSpeed;
    public float rSpeed;
    public float uSpeed;
    public float dSpeed;

    public int money;

    public Animator anim;
    public MiniGameController control;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(control.timeUp == false && control.started == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(!Input.anyKey)
        {
            AnimReset();
            anim.SetBool("Flying", true);
        }

        if (Input.GetKey(KeyCode.W) && control.timeUp == false)
        {
            transform.Translate(Vector3.up * uSpeed * Time.deltaTime);
            AnimReset();
            anim.SetBool("FlyingU", true);
        }

        if (Input.GetKey(KeyCode.A) && control.timeUp == false)
        {
            transform.Translate(Vector3.left * lSpeed * Time.deltaTime);
            AnimReset();
            anim.SetBool("FlyingL", true);
        }

        if (Input.GetKey(KeyCode.S) && control.timeUp == false)
        {
            transform.Translate(Vector3.down * dSpeed * Time.deltaTime);
            AnimReset();
            anim.SetBool("FlyingD", true);
        }

        if (Input.GetKey(KeyCode.D) && control.timeUp == false)
        {
            transform.Translate(Vector3.right * rSpeed * Time.deltaTime);
            AnimReset();
            anim.SetBool("FlyingR", true);
        }
    }

    public void AnimReset()
    {
        anim.SetBool("Flying", false);
        anim.SetBool("FlyingU", false);
        anim.SetBool("FlyingL", false);
        anim.SetBool("FlyingD", false);
        anim.SetBool("FlyingR", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ring")
        {
            money += 5;
            PlayerGold.instance.totalGold += 5;
        }
    }
}
