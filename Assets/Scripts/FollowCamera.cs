using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject followPosition;

    void Start()
    {
    }
    
    void Update()
    {
        transform.position = followPosition.transform.position;   
    }
}
