using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    GameObject player;
    //Vector3 playerStartPos;

    Vector3 respawnPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
       // playerStartPos = player.transform.position;
        respawnPos = transform.GetChild(0).position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPos;
        }
    }
}
