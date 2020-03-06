using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth { get; set; }
    bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;

    }

    void Update()
    {


    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        if (currentHealth == 0)
        {
            Die();
        }
    }
    public void Die()
    {
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");

        }
    }

    
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
    }
}
