using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPower : MonoBehaviour
{
    public int selectedCharacter = 0;
    AudioSource ac;
    public AudioClip clickySound;

    private void Start()
    {
        ac = GetComponent<AudioSource>();
    }

    public void Babarian()
    {
        selectedCharacter = 0;
        ac.PlayOneShot(clickySound, 0.8f);
    }
    
    public void WickJohn()
    {
        ac.PlayOneShot(clickySound, 0.8f);
        selectedCharacter = 1;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }
}
