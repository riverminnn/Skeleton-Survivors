using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameLocation : MonoBehaviour
{
    int i = 0;
    AudioSource ac;
    public AudioClip enteringSound;
    public GameObject Spawner;

    private void Awake()
    {
        ac = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touch " + other.name);
        i++;
    }

    private void Update()
    {
        if (i == 1)
        {
            Spawner.SetActive(true);
            StartCoroutine(Play());
            i++;
        }    
    }

    IEnumerator Play()
    {
        ac.PlayOneShot(enteringSound, 1f);
        yield return new WaitForSeconds(4);
        Debug.Log("Play");
    }


}
