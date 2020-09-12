using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private float maxHealth;
    private float currentHealth;
    public event Action onDeath;
    public event Action onDamageTaken;
    public HealthSystem (float maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }
    public void Damage(float amount)
    {
        if(amount < currentHealth)
        {
            currentHealth -= amount;
            onDamageTaken?.Invoke();
        }
        else
        {
            currentHealth = 0;
            onDeath?.Invoke();
        }
    }
    public void Heal(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public float GetHealth()
    {
        return currentHealth;
    }
    //returns a decimal 0 - 1
    public float GetHealthPercent()
    {
        return (currentHealth / maxHealth);
    }
}
