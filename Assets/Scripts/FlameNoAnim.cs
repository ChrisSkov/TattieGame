using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameNoAnim : MonoBehaviour
{
    [SerializeField] GameObject flameObj;

    // Start is called before the first frame update
    void Start()
    {
        flameObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            flameObj.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            flameObj.SetActive(false);
        }
    }
}
