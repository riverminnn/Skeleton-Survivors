using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;

    private void Awake()
    {
        int theOne = PlayerPrefs.GetInt("selectedCharacter", 0);
        if (theOne == 0)
        {
            characterPrefabs[1].SetActive(false);
            characterPrefabs[0].SetActive(true);
        }
        else if (theOne == 1)
        {
            characterPrefabs[0].SetActive(false);
            characterPrefabs[1].SetActive(true);
        }
    }

}
