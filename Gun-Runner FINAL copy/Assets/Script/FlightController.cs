using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float speed = 30.0f;
    public float rotSpeed = 150.0f;
    public float boostSpeed = 70.0f;
    public bool boosting = false;
    public bool stopped = false;
    public static float interpolator = 1.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //MOVEMENT CONTROLS
        float translation = /*Input.GetAxis("Vertical") **/ speed;
        float xRotation = Input.GetAxis("Mouse X") * rotSpeed;
        float yRotation = Input.GetAxis("Mouse Y") * rotSpeed;
        float zRotation = Input.GetAxis("Horizontal") * rotSpeed;

        translation *= Time.deltaTime;
        xRotation *= Time.deltaTime;
        yRotation *= Time.deltaTime;
        zRotation *= Time.deltaTime;
        speed *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(Vector3.up * xRotation);
        transform.Rotate(Vector3.left * yRotation);
        transform.Rotate(Vector3.back * zRotation);


        //SPEED BOOST & SLOW
        if (Input.GetKeyDown(KeyCode.W))
        {
            boosting = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            boosting = false;
        }

        if (boosting == true && stopped == false)
        {
            speed = boostSpeed;
        }

        if (boosting == false && stopped == false)
        {
            speed = 30.0f;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            stopped = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            stopped = false;
        }

        if (stopped == true && boosting == false)
        {
            speed = 15.0f;
        }

        if (stopped == false && boosting == false)
        {
            speed = 30.0f;
        }

        //MOUSE UNLOCK
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
