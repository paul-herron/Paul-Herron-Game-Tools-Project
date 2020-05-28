using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public bool alerted;
    public Transform lookTarget;
    public float turretSpeedOn = 0.1f;
    public float turretSpeedOff = 0.5f;
    private float _interpolator = 1.0f;
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    private Vector3 _aimVec;

    void Start()
    {
        if (lookTarget == null)
        {
            lookTarget = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {

        if (alerted)
        {
            _interpolator = Mathf.Lerp(_interpolator, 1.0f, turretSpeedOn);

            if (_interpolator > 0.9f)
            {
                Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.identity);
            }
        }

        else
        {
            _interpolator = Mathf.Lerp(_interpolator, 0.0f, turretSpeedOff);
        }

        _aimVec = lookTarget.position - transform.position;

        Quaternion gunQuat = Quaternion.LookRotation(_aimVec);
        transform.rotation = Quaternion.Slerp(Quaternion.identity, gunQuat, _interpolator);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") alerted = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") alerted = false;
    }
}
