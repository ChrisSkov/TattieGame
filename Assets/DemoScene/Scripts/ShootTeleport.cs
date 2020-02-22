using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTeleport : MonoBehaviour
{
    [SerializeField] GameObject projectileSocket;
    [SerializeField] float projectileSpeed = 10f;
    //   [SerializeField] float tpOffset = 2f;
    [SerializeField] float teleportTime = 1.8f;
    [SerializeField] float timeBeforeTP = .5f;
    [SerializeField] float cooldown = 2f;
    [SerializeField] Rigidbody projectilePrefab;
    Rigidbody rb;
    public float timer = Mathf.Infinity;
    public Rigidbody clone;
    public bool canTP = false;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // print(timer);
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Q)/* && timer >= cooldown*/)
        {
            if (timer >= cooldown)
            {
                canTP = true;
                timer = 0;
                clone = Instantiate(projectilePrefab, projectileSocket.transform.position, projectileSocket.transform.rotation);
                clone.AddRelativeForce(Vector3.forward * projectileSpeed, ForceMode.Impulse);
            }

            if (canTP && timer > timeBeforeTP && timer <= teleportTime)
            {
                // Vector3 tpPos= new Vector3(clone.position.x, clone.position.y, clone.position.z - tpOffset);
                rb.position = clone.position;
                Destroy(clone.gameObject);
                timer = 0;
                canTP = false;
            }

        }

    }
}
