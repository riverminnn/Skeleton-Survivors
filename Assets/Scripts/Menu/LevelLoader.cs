using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    private void Update()
    {
        
    }

    public void Play()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(2);

        transition.SetTrigger("back");
    }
}
