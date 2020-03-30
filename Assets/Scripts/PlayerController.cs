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
    Fight fight;
    // Start is called before the first frame update
    void Start()
    {
        fight = GetComponent<Fight>();
        health = GetComponent<Health>();
        rbMove = GetComponent<RigidBodyMovement>();
        flame = GetComponent<FlameThrowing>();
        shootTP = GetComponent<ShootTPv2>();
        camControl = GetComponent<CamController>();
    }


    void Update()
    {
        if (health.IsDead())
        {
            fight.enabled = false;
            rbMove.enabled = false;
            flame.StopFlame();
            flame.enabled = false;
            shootTP.enabled = false;
            camControl.enabled = false;
        }
    }


}
