using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject chooseCharacterMenu;

    public AudioClip clickySound;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayButtonAtMainMenu()
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        mainMenu.SetActive(false);
        chooseCharacterMenu.SetActive(true);
    }

    public void OptionsButton()
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        audioSource.PlayOneShot(clickySound, 0.8f);
        EditorApplication.ExitPlaymode();
#else   
        audioSource.PlayOneShot(clickySound, 0.8f);
        Application.Quit();
#endif
    }

    public void ReturnInOptions()
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ReturnInChooseCharacter()
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        chooseCharacterMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayInChooseCharacter()
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(1);
    }
}
