using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameOver : MonoBehaviour
{

    [SerializeField] Health playerHP;
    PlayerController playerControl;
    NavigateUI navUI;
    GameObject[] enemies;
    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        navUI = playerHP.gameObject.GetComponent<NavigateUI>();
        playerControl = playerHP.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (playerHP.IsDead() || GetComponent<ChickenManager>().chickens.Length == 0)
        {
            gameOver = true;
        }
        if (IsGameOver())
        {
            navUI.ShowGameOverMenu();
            navUI.CursorBehavior();
            playerControl.DisableControl();
            foreach (var enemy in enemies)
            {
                enemy.GetComponent<NavMeshAgent>().isStopped = true;
                enemy.GetComponent<AICombat>().enabled = false;
            }
        }
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}
