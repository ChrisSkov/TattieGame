using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehavior : MonoBehaviour
{
    [SerializeField] GameObject chickenLeg;
    Health health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnChickenLeg();
    }

    void SpawnChickenLeg()
    {

        if (health.IsDead())
        {
            var clone = Instantiate(chickenLeg, transform.position, transform.rotation);
        }
    }
}
