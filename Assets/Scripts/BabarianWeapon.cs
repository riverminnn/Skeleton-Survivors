using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabarianWeapon : MonoBehaviour
{
    public GameObject Axe;
    private bool CanAttack = true;
    public float AttackCooldown = 0.3f;
    public bool isAttacking = false;

    public Camera fpsCam;
    protected float range = 10f;
    protected int damage = 150;
    public float impactForce = 60f;

    public AudioClip AxeAttackSound;
    public GameObject HitParticle;

    private void Update()
    {
        if (!PauseMenu.GameIsPause)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CanAttack)
                {
                    AxeAttack();
                }
            }
        } 
    }

    public void AxeAttack()
    {
        CanAttack = false;
        isAttacking = true;
        Animator anim = Axe.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(AxeAttackSound, 0.5f);
        
        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            //enemy.GetComponent<Animator>().SetTrigger("Hit");
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject hitGO = Instantiate(HitParticle, hit.point, Quaternion.LookRotation(hit.normal));
            
            Destroy(hitGO, 1.5f);
        }
        StartCoroutine(ResetAttackCoolDown());
    }

    IEnumerator ResetAttackCoolDown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
