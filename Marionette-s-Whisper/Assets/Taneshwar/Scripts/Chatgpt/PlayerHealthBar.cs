using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthSlider; // Reference to the UI slider for the health bar
    public int maxHealth = 100; // Maximum health value for the player
    public int fallDamage = 20; // Amount of damage taken when falling and hitting the terrain
    private int currentHealth; // Current health value for the player

    private void Start()
    {
        currentHealth = maxHealth; // Set the initial health to the maximum value
        UpdateHealthBar(); // Update the health bar UI
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Subtract the damage amount from the current health
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure that the current health doesn't go below zero
        UpdateHealthBar(); // Update the health bar UI

        if (currentHealth <= 0)
        {
            // Handle player death here
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount; // Add the heal amount to the current health
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure that the current health doesn't exceed the maximum
        UpdateHealthBar(); // Update the health bar UI
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth; // Update the slider value to reflect the current health
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            // Check if the collision is with the terrain
            if (collision.relativeVelocity.magnitude > 10f)
            {
                // Check if the player's relative velocity is above a certain threshold
                TakeDamage(fallDamage); // Player takes damage from falling
            }
        }
    }
}