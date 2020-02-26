using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth {get;set;}
    void Start()
    {
        currentHealth = maxHealth;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            currentHealth -= 10f;
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }


    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
    }
}
