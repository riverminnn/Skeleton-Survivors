using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float health = 150f;
    public Animator anim;
    public static Enemy instance;

    public int deadIndex;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        deadIndex = Random.Range(1, 3);
        anim = GetComponent<Animator>();
    }

    IEnumerator Wait()
    {
        if (deadIndex == 1)
            anim.SetTrigger("DEAD");
        else if (deadIndex == 2)
            anim.SetTrigger("DEAD2");
        yield return new WaitForSeconds(1.5f);
        Player.instance.AddScore(Random.Range(100, 1000));
        if (gameObject != null)
            Destroy(gameObject);
    }


    private void Update()
    {
        
        anim.SetTrigger("Walk");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(other.name);
            
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(Wait());
    }
    
    
   
}
