using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravBody : MonoBehaviour
{
    public GravAttractor attract;
    private Transform myTransform;

    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
    }

    void Update()
    {
        attract.Attract(myTransform);
    }
}
