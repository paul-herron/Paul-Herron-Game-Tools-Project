using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //VALUES
    public float damage = 10f;
    public float range = 100f;
    public float fireRate;

    private float _nextShot = 0f;

    //OBJECTS
    public Camera playerCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactFlash;
    public AudioSource gunShot;
    void Update()

    {
        if (Input.GetButton("Fire1") && Time.time >= _nextShot)
        {
            _nextShot = Time.time + 4f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        gunShot.Play();

        RaycastHit hit;
        Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range);

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Physics.IgnoreLayerCollision(0 >> 10, 11);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

           GameObject impactGO = Instantiate(impactFlash, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactGO, 2f);
        }


    }
}
