using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float destroyTime = 2f;
    Collider player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), player);
        Destroy(gameObject, destroyTime);
    }
}
