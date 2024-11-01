using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI survivalText;
    public string playerName;
    [SerializeField] TextMeshProUGUI TopText;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] AudioClip clickySound;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject story;
    [SerializeField] GameObject healthBar;
    public AudioClip storySound;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI scoreTextOver;
    public int highScore;
    public int score;
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    public void SavePlayer()
    {
        audioSource.PlayOneShot(clickySound, 0.8f);
        SaveSystem.SavePlayer(this);
    }

    private void Start()
    {
        inputField.characterLimit = 16;
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(WatchStory());
        LoadPlayer();
        LoadPlayerMenu();
    }

    public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPlayer();

        playerName = data.PlayerName;

        survivalText.text = playerName;
    }

    public void LoadPlayerMenu()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        playerName = data.PlayerName;

        TopText.text = "Last survivor: " + playerName;
    }
    public void Update()
    {
        playerName = survivalText.text;
        scoreText.text = "Score: " + score;
        highscoreText.text = "Highscore: " + highScore;
        scoreTextOver.text = "" + score;
    }

    IEnumerator WatchStory()
    {
        audioSource.PlayOneShot(storySound, 1f);
        healthBar.SetActive(false);
        story.SetActive(true);

        yield return new WaitForSeconds(5);

        story.SetActive(false);
        healthBar.SetActive(true);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        
        if (highScore < score)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
        }
    }
}
