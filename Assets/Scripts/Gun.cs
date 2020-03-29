using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Gun : MonoBehaviour
{
    enum gunmode
    {
        fullauto,
        semiauto,
        shotgun
    }

    [SerializeField] private gunmode Mode;

    [SerializeField] private int shellFragments = 1;
    [SerializeField] private float fireRate = 15f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 150f;
    [SerializeField][Range(0f,1f)] private float spread = 0.05f;



    [SerializeField] private Camera fpsCam;

    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject impactEffect;

    private float nextTimeToFire = 0f;
    
    

    private void Update()
    {
        switch (Mode)
        {
            case gunmode.fullauto:
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }

                break;
            case gunmode.semiauto:
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }

                break;
            case gunmode.shotgun:
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    for (int i = 0; i < shellFragments; i++)
                    {
                        Shoot();
                    }
                }
                break;
            default:
                break;
        }


    }
    public void Shoot()
    {
    muzzleFlash.Play();
        
        RaycastHit hit;
        Vector3 forwardPlusDevation = fpsCam.transform.forward + new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));
        if (Physics.Raycast(fpsCam.transform.position, forwardPlusDevation, out hit, range))
        {
            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 0.5f);
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyBehaviour>().DealDamage(damage);
            }
        }
    }
}
