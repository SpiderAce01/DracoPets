using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationY = 0f;
    public float rotationX = 0f;
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rotationY += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotationY -= speed * Time.deltaTime;
        }

        rotationY = Mathf.Clamp(rotationY, 80, 180);
        var rotY = transform.localEulerAngles;
        rotY.y = rotationY;
        transform.localEulerAngles = -rotY;

        if (Input.GetKey(KeyCode.W))
        {
            rotationX += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rotationX -= speed * Time.deltaTime;
        }

        rotationX = Mathf.Clamp(rotationX, -90, 90);
        var rotX = transform.localEulerAngles;
        rotX.x = rotationX;
        transform.localEulerAngles = -rotX;
    }
}
