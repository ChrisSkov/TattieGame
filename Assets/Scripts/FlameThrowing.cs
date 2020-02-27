using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowing : MonoBehaviour
{
    [SerializeField] GameObject flameObj;
    [SerializeField] float flameDistance = 10f;
    [SerializeField] float flameDamage = 10f;
    [SerializeField] float tickTime = 0.5f;
    bool flameIsActive;
    Animator anim;
    Transform flameAim;
    float timer = Mathf.Infinity;
    bool flameRoutineIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        flameAim = flameObj.transform.GetChild(0);
        anim = GetComponent<Animator>();
        flameObj.SetActive(false);
    }

    // Update is called once per frame

    void Update()
    {
        // print(timer);
        timer += Time.deltaTime;
        //print(anim.GetBool("Flaming"));
        FlameAnim();
        Debug.DrawRay(flameAim.transform.position, flameAim.transform.TransformDirection(Vector3.forward) * flameDistance, Color.yellow);
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
            flameObj.SetActive(false);
            // print("ses");
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
            StopCoroutine("DamageTick");
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            if (!flameRoutineIsRunning)
            {

                StartCoroutine(FlameDamage(enemyHealth));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        flameRoutineIsRunning = false;
        StopCoroutine("FlameDamage");
    }
    IEnumerator FlameDamage(Health enemyHealth)
    {
        flameRoutineIsRunning = true;
        enemyHealth.TakeDamage(flameDamage);
        yield return new WaitForSeconds(tickTime);
    }


}
