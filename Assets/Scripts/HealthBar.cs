using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public AudioClip hurtSound;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMaxHealth(int health)
    {
        
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        audioSource.PlayOneShot(hurtSound, 0.3f);
        slider.value = health;
    }
}
