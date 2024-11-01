using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WickJohnWeapon : MonoBehaviour
{
    protected float damage = 12f;
    protected float range = 200f;
    protected float fireRate = 8f;

    public GameObject hitParticle;
    public AudioClip shootingSound;
    public ParticleSystem shootParticle;

    public float impactForce = 100f;
    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    private void Update()
    {
        if (PauseMenu.GameIsPause == false)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        shootParticle.Play();
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(shootingSound, 0.1f);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject hitGO = Instantiate(hitParticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hitGO, 1.5f);
        }
        
    }
}
