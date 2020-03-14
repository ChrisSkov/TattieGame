using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenName : MonoBehaviour
{
    public string[] chickenNames = new string[] { "Kvisten", "Paul", "George", "Steve", "Mert", "Warløkke", "Lars", "ChrilleBob" };
    GameObject[] chickens;
    Text chickenName;
    bool hasName = false;
    // Start is called before the first frame update
    void Start()
    {
        chickenName = GetComponent<Text>();
        chickens = GameObject.FindGameObjectsWithTag("chicken");
    }

    // Update is called once per frame
    void Update()
    {
        NameTheChickens();
    }
    void NameTheChickens()
    {
        foreach (GameObject chicken in chickens)
        {
            if (!hasName)
            {
                int myName = Random.Range(0, chickenNames.Length - 1);
                chickenName.text = chickenNames[myName];
                hasName = true;
            }
        }
    }
}
