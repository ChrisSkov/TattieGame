using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] float healAmount = 20f;
    Health health;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindWithTag("Player").GetComponent<Health>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == health.gameObject)
        {
            health.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
