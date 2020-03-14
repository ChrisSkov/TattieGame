using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenCounter : MonoBehaviour
{
    public GameObject[] chickens;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        chickens = GameObject.FindGameObjectsWithTag("chicken");
        text.text = string.Format("Chickens: {0}", chickens.Length);


    }
   
}
