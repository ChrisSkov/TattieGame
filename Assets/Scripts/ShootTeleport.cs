using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTeleport : MonoBehaviour
{
    [Header("Components")]
    [Tooltip("Where are we shooting from")]
    [SerializeField] GameObject projectileSocket;
    [Tooltip("What are we shooting")]
    [SerializeField] Rigidbody projectilePrefab;
    [Header("Look and feel")]
    [Tooltip("How fast is the projectile")]
    [SerializeField] float projectileSpeed = 10f;
    [Tooltip("How long can we decide to teleport?")]
    [SerializeField] float teleportTime = 1.8f;
    [Tooltip("How long do we have to wait before we can teleport?")]
    [SerializeField] float timeBeforeTP = .5f;
    [Tooltip("When can we shoot again?")]
    [SerializeField] float cooldown = 2f;
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
