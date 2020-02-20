using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTeleport : MonoBehaviour
{
    [SerializeField] GameObject projectileSocket;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float teleportTime = 1.8f;
    [SerializeField] float timeBeforeTP = .5f;
    [SerializeField] float cooldown = 2f;
    [SerializeField] Rigidbody projectilePrefab;
    Rigidbody rb;
    float timer = Mathf.Infinity;
    Rigidbody clone;
    bool canTP = false;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        print(timer);
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q)/* && timer >= cooldown*/)
        {
            if (timer >= cooldown)
            {
                canTP = true;
                timer = 0;
                clone = Instantiate(projectilePrefab, projectileSocket.transform.position, projectileSocket.transform.rotation);
                clone.AddForce(Vector3.forward * projectileSpeed, ForceMode.Impulse);
            }

            if (canTP && timer > timeBeforeTP && timer <= teleportTime)
            {
                rb.MovePosition(new Vector3(clone.position.x, rb.position.y, clone.position.z));
                Destroy(clone.gameObject);
            }

        }

    }
}
