using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTPv2 : MonoBehaviour
{
    [Header("Components")]
    [Tooltip("Where are we shooting from?")]
    [SerializeField] GameObject projectileSocket;
    [Tooltip("What are we shooting?")]
    [SerializeField] GameObject originalBullet;
    [Header("Balancing")]
    [Tooltip("How fast is the projectile?")]
    [SerializeField] float projectileSpeed;
    [Tooltip("When can we shoot again?")]
    [SerializeField] float cooldown = 2f;
    GameObject clone;

    Rigidbody rb;
    float timer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F) && timer > cooldown)
        {

            clone = Instantiate(originalBullet, projectileSocket.transform.position, projectileSocket.transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(projectileSocket.transform.forward * projectileSpeed, ForceMode.Impulse);
            timer = 0;

        }
        if (Input.GetKeyDown(KeyCode.E) && clone != null)
        {
            rb.position = clone.transform.position;
            Destroy(clone);
        }

    }
}
