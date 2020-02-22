using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowing : MonoBehaviour
{
    [SerializeField] GameObject flameObj;
    bool flameIsActive;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        flameObj.SetActive(false);
    }

    // Update is called once per frame

    void Update()
    {

        //print(anim.GetBool("Flaming"));
        FlameAnim();
    }

    void FlameAnim()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("Flaming", true);

            // flameIsActive = true;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetBool("Flaming", false);
            // flameObj.SetActive(false);
            print("ses");
        }
    }
    void ActivateFlame()
    {
        if (anim.GetBool("Flaming"))
        {
            flameObj.SetActive(true);//TODO: Refactor repeating code
        }

        if (anim.GetBool("Flaming") == false)
        {
            flameObj.SetActive(false);//TODO: Refactor repeating code
        }

        // if(!flameIsActive && Input.GetKeyDown(KeyCode.Q))
        // {
        //     flameObj.SetActive(true);//TODO: Refactor repeating code
        //     flameIsActive = true;
        //     print("eow");
        // }
        // else if(Input.GetKeyDown(KeyCode.Q))
        // {
        //     flameObj.SetActive(false);
        //     flameIsActive = false;
        // }


    }


}
