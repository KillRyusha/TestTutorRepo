using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar;  // Полоска здоровья
    public TMP_Text healthText;   // Числовое отображение здоровья

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHealthUI()
    {
        healthBar.value = currentHealth;
        healthText.text = $"{currentHealth} / {maxHealth}";
    }
}
