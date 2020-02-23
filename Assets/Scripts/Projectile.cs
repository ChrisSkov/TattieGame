using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float destroyTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(9, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
