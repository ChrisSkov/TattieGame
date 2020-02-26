using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] Text hpText;
   [SerializeField] Slider hpBar;

    float currentHealth;
    float maxHealth;
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        maxHealth = health.GetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = health.GetCurrentHealth();
        hpBar.value = currentHealth;

        hpText.text = string.Format("{0}/{1}", currentHealth, maxHealth);

    }
}
