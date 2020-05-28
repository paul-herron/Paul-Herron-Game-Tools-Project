using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterCollision : MonoBehaviour
{


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            FindObjectOfType<gameManager>().EndGame();
            FindObjectOfType<FlightController>().enabled = false;
        }
    }
}