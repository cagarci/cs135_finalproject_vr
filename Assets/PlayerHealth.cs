using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [Tooltip("Player's health")]
    public int currentHealth;
    [Tooltip("UI element to draw health as number")]
    public Text healthUIText;
    [Tooltip("UI element to draw health as slider")]
    public Slider healthUISlider;
    public Text playerStats;
    public int startingHealth = 100;
    
    public float restTime = 5.0f;
    float timer;
    public Image damageImage;

    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    AudioSource playerAudio;
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    // Start is called before the first frame update
    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DrawPlayerStats();
        DrawHealthStats();
        timer += Time.deltaTime;
        if (damaged)
        {
            timer = 0;
        }
        if(timer >= restTime&&currentHealth < 100)
        {
            RegenHealth();
            timer = 0;
        }
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        
        // Reset the damaged flag.
        damaged = false;
        
    }
    public void TakeDamage()
    {
        
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= 5;
        //playerAudio.Play();
        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }

    public void RegenHealth()
    {
        if(100 - currentHealth <= 10)
        {
            currentHealth = 100;
        }
        else
        {
            currentHealth += 10;
        }
    }
    void Death()
    {
       
    }

    public void DrawPlayerStats()
{
    if (playerStats != null)
        playerStats.text = string.Format("--- Player statistic ---\n\n\n - Health: {0}\n\n", currentHealth);
}
    void DrawHealthStats()
    {
        if (healthUIText != null)
            healthUIText.text = currentHealth.ToString();

        if (healthUISlider != null)
            healthUISlider.value = currentHealth;
    }
}