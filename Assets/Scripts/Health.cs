using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public Slider hpBar;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;

    }

    void Update()
    {
        hpBar.value = currentHealth;

        if (Input.GetKeyDown(KeyCode.M))
        {
            currentHealth -= 10f;
        }
    }

    public Slider GetHpBar()
    {
        return hpBar;
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
}
