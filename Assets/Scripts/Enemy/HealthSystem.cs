using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 10;
    float currentHealth;

    public Image mask;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth -= _damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void UpdateHealthBar()
    {
        float fill = currentHealth / maxHealth;
        mask.fillAmount = fill;
        if (currentHealth < 0)
        {
            mask.fillAmount = 0;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}