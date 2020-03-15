using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public float score;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("Score: {0}", score);

    }
}
