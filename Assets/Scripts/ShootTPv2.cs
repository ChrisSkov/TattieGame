using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTPv2 : MonoBehaviour
{
    [SerializeField] GameObject projectileSocket;
    [SerializeField] GameObject originalBullet;

    [SerializeField] float projectileSpeed;

    [SerializeField] float cooldown = 2f;
    [SerializeField] float range = 100f;
    //public float timer = Mathf.Infinity;
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
        if(Input.GetKeyDown(KeyCode.F) && timer> cooldown)
        {
        
            timer = 0;
            clone = Instantiate(originalBullet, projectileSocket.transform.position, projectileSocket.transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(projectileSocket.transform.forward * projectileSpeed, ForceMode.Impulse);

        }
        if(Input.GetKeyDown(KeyCode.E) && clone != null)
        {
            rb.position = clone.transform.position;
            Destroy(clone);
        }

    }
}
