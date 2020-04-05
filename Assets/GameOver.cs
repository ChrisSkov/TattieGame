using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

   [SerializeField] Health playerHP;

    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHP.IsDead() || GetComponent<ChickenManager>().chickens.Length ==0)
        {
            gameOver = true;
        }
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}
