using UnityEngine;
using TMPro;

public class HealthController : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public TMP_Text healthText; // Reference to a TextMeshProUGUI component to display current health

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth <= 0)
            return;


        currentHealth -= damageAmount;

        if (currentHealth <= 0f)
        {
            Die();
        }

        UpdateHealthText();
    }

    public void Heal(float healAmount)
    {
        if (currentHealth <= 0)
            return;

            
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthText();
    }

    private void Die()
    {
        // Perform death actions
        Destroy(gameObject);
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            int healthValue = Mathf.RoundToInt(currentHealth); // Convert currentHealth to integer
            healthText.text = "Health: " + healthValue.ToString();
        }
    }

}
