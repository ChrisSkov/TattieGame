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
    NavigateUI navUI;
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameOver gameOverObject;
    // Start is called before the first frame update
    void Start()
    {
        navUI = GetComponent<NavigateUI>();
        fight = GetComponent<Fight>();
        health = GetComponent<Health>();
        rbMove = GetComponent<RigidBodyMovement>();
        flame = GetComponent<FlameThrowing>();
        camControl = GetComponent<CamController>();
    }


    void Update()
    {


        if (gameMenu.gameObject.activeSelf == true)
        {

            DisableControl();
        }
        else
        {
            EnableControl();
        }

        // if (gameOverObject.IsGameOver())
        // {
        //     navUI.ShowGameOverMenu();
        //     navUI.CursorBehavior();
        //     DisableControl();
        // }
    }
    public void DisableControl()
    {
        fight.enabled = false;
        rbMove.enabled = false;
        flame.StopFlame();
        flame.enabled = false;
        camControl.enabled = false;
    }
    public void EnableControl()
    {
        fight.enabled = true;
        rbMove.enabled = true;
        flame.enabled = true;
        camControl.enabled = true;
    }
}
