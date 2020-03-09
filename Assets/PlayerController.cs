using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Health health;
    RigidBodyMovement rbMove;
    FlameThrowing flame;
    ShootTPv2 shootTP;
    CamController camControl;
    AudioControl audioControl;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        rbMove = GetComponent<RigidBodyMovement>();
        flame = GetComponent<FlameThrowing>();
        shootTP = GetComponent<ShootTPv2>();
        camControl = GetComponent<CamController>();
        audioControl = GetComponent<AudioControl>();
    }


    void Update()
    {
        if (health.IsDead())
        {
            rbMove.enabled = false;
            flame.StopFlame();
            flame.enabled = false;
            shootTP.enabled = false;
            camControl.enabled = false;
            audioControl.enabled = false;
        }
    }

}
