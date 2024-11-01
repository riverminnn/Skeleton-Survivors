using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// [INHERITANCE]
public class BabarianMovement : PlayerMovement
{
    // [POLYMORPHISM]
    protected int babarianMaxHealth = 1500;
    public int currentHealth;

    public GameObject gameOverMenu;

    public HealthBar healthBar;
    public AudioClip GameOverSound;
    public AudioClip RestartSound;
    public GameObject Spawner;

    private float babarianSpeed = 9f;
    private float babarianJumpHeight = 1.5f;
    private float babarianSprintingSpeed = 1.5f;

    AudioSource ac;

    // [ABSTRACTION]
    private void Start()
    {
        ac = GetComponent<AudioSource>();
        currentHealth = babarianMaxHealth;
        healthBar.SetMaxHealth(babarianMaxHealth);
    }
    private void Update()
    {
        PlayerMove();
    }

    new void PlayerMove()
    {
        CheckGame();
        speed = babarianSpeed;
        jumpHeight = babarianJumpHeight;
        sprintSpeed = babarianSprintingSpeed;
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
