using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 _aimVec;
    public Transform aimTarget;

    void Start()
    {
        Destroy(this.gameObject, 1f);
        aimTarget = GameObject.FindWithTag("Player").transform;
        _aimVec = aimTarget.position - transform.position;
    }

    void Update()
    {
        transform.position += _aimVec * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("Player Hit!");
        }
    }
}
