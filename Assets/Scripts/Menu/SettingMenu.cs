using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingMenu : MenuUIHandler
{
    [SerializeField] Slider volumeSlider;
    public AudioMixer audioMixer;
    public TextMeshProUGUI qualityText;
    [SerializeField] int qualityTextIndex = 3;
    [SerializeField] TextMeshProUGUI sizeText;
    int fullScrIndex;
    int width;
    int height;

    [SerializeField] Toggle toggle;

    bool fullScreenStatus;


    List<int> widths = new List<int>() { 1280, 1600, 1920 };
    List<int> heights = new List<int>() { 720, 900, 1080 };
    private void Start()
    {
        DefaultVolume();
        DefaultQuality();
        AudioListener.volume = volumeSlider.value;
    }

    public void SetScreenSize(int index)
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        width = widths[index];
        height = heights[index];
        Screen.SetResolution(width, height, fullScreenStatus);
    }

    private void Update()
    {
        GetFullScreenBoolIndex();
        ChangeQuality();
        SetQuality();
    }

    

    public void DefaultVolume()
    {
        if (!PlayerPrefs.HasKey("qualityIndex"))
        {
            PlayerPrefs.SetFloat("qualityIndex", 2);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }

    public void DefaultQuality()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            LoadQuality();
            sizeText.text = width + " x " + height;
        }
        else
        {
            LoadQuality();
        }
    }


    public void ChangeQuality()
    {
        if (qualityTextIndex == 1)
            qualityText.text = "Low";
        else if (qualityTextIndex == 2)
            qualityText.text = "Mid";
        else if (qualityTextIndex == 3)
            qualityText.text = "High";
        else if (qualityTextIndex == 4)
            qualityTextIndex = 3;
        else if (qualityTextIndex == 0)
            qualityTextIndex = 1;
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    public void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.8f);
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void LoadQuality()
    {
        qualityTextIndex = PlayerPrefs.GetInt("qualityIndex", qualityTextIndex);
        fullScrIndex = PlayerPrefs.GetInt("fullScrIndex", fullScrIndex);
        width = PlayerPrefs.GetInt("screenWidth", width);
        height = PlayerPrefs.GetInt("screenHeight", height);
    }

    public void SaveQuality()
    {
        PlayerPrefs.SetInt("qualityIndex", qualityTextIndex);
        PlayerPrefs.SetInt("fullScrIndex", fullScrIndex);
        PlayerPrefs.SetInt("screenWidth", width);
        PlayerPrefs.SetInt("screenHeight", height);
    }

    public void RightButtonQuality()
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        if (qualityTextIndex > 0 && qualityTextIndex < 4)
            qualityTextIndex += 1;
    }

    public void LeftButtonQuality()
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        if (qualityTextIndex > 0 && qualityTextIndex < 4)
            qualityTextIndex -= 1;
    }

    public void SetQuality()
    {
        if (qualityTextIndex == 1)
        {
            QualitySettings.SetQualityLevel(0, false);
            SaveQuality();
        }
            
        else if (qualityTextIndex == 2)
        {
            QualitySettings.SetQualityLevel(1, false);
            SaveQuality();
        }
            
        else if (qualityTextIndex == 3)
        {
            QualitySettings.SetQualityLevel(2, false);
            SaveQuality();
        }
            
    }

    public void SetFullScreen(bool isFullScreen)
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        fullScreenStatus = isFullScreen;
        Screen.fullScreen = fullScreenStatus;
    }

    public void GetFullScreenBoolIndex()
    {
        if (fullScreenStatus == true)
            fullScrIndex = 1;
        else
            fullScrIndex = 0;
    }
}
