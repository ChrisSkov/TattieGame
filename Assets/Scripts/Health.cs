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
}
