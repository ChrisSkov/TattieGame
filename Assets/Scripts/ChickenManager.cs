using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenManager : MonoBehaviour
{

    public string[] chickenNames = new string[] { "Kvisten", "Paul", "George", "Steve", "Mert", "Warløkke", "Lars", "ChrilleBob", "Berta", "Jørgen", "Preben", "Destroyer Of Worlds" };
    [SerializeField] Text chickenCounter;
    GameObject[] chickens;
    Text chickenName;
    // Start is called before the first frame update
    void Start()
    {
        NameTheChickens();
    }

    // Update is called once per frame
    void Update()
    {
        chickens = GameObject.FindGameObjectsWithTag("chicken");
        chickenCounter.text = string.Format("Chickens: {0}", chickens.Length);

    }
    void NameTheChickens()
    {
        foreach (GameObject chicken in chickens)
        {
            chickenName = chicken.gameObject.GetComponentInChildren<Text>();
            int myName = Random.Range(0, chickenNames.Length - 1);
            chickenName.text = chickenNames[myName];

        }
    }
}
