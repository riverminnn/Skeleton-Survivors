using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// [INHERITANCE]
public class WickJohnMovement : PlayerMovement
{
    // [POLYMORPHISM]
    protected int WJMaxHealth = 250;
    public int currentHealth;

    public GameObject gameOverMenu;

    public HealthBar healthBar;
    public AudioClip GameOverSound;
    public AudioClip RestartSound;
    public GameObject Spawner;

    private float WJSpeed = 18f;
    private float WJJumpHeight = 2.7f;
    private float WJSprintingSpeed = 2f;

    AudioSource ac;

    private void Start()
    {
        ac = GetComponent<AudioSource>();
        currentHealth = WJMaxHealth;
        healthBar.SetMaxHealth(WJMaxHealth);
    }

    // [ABSTRACTION]
    private void Update()
    {
        PlayerMove();
    }

    // [POLYMORPHISM]
    new void PlayerMove()
    {
        CheckGame();
        speed = WJSpeed;
        jumpHeight = WJJumpHeight;
        sprintSpeed = WJSprintingSpeed;
        base.PlayerMove();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemySword")
        {
            TakeDamage(10);
        }
    }

    void GameOver()
    {
        Spawner.SetActive(false);
        ac.PlayOneShot(GameOverSound, 0.05f);
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    void PlayAgain()
    {
        ac.PlayOneShot(RestartSound, 0.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    void CheckGame()
    {
        if (currentHealth <= 0f)
        {
            GameOver();
            Wait();
            if (Input.GetButtonDown("Jump"))
            {
                PlayAgain();
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }

}
