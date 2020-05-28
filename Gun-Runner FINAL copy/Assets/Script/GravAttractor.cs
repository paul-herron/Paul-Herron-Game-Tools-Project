﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravAttractor : MonoBehaviour
{
    public float gravity = -10;
    public void Attract(Transform body)
    {
        //SIMULATES GRAVITY TO KEEP ENEMY SKYCARS FROM FLYING OFF INTO SPACE
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
