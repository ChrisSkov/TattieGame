using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowing : MonoBehaviour
{
    [SerializeField] GameObject flameObj;
    [SerializeField] float flameDamage = 10f;
    [SerializeField] float tickTime = 0.2f;
    [SerializeField] float flameRadius = 3f;
    Animator anim;
    [SerializeField] Transform flameAim;
    [SerializeField] float timer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        //flameAim = flameObj.transform.GetChild(0);
        anim = GetComponent<Animator>();
        flameObj.SetActive(false);
    }
    void Update()
    {
        FlameAnim();

        OverlapCapsule();

    }




    void FlameAnim()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("Flaming", true);
            //OverlapCapsule();   
            // OverlapCapsule();
            // StartTick();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetBool("Flaming", false);
            flameObj.SetActive(false);
        }
    }
    void ActivateFlame()
    {
        if (anim.GetBool("Flaming"))
        {
            flameObj.SetActive(true);


        }

        if (anim.GetBool("Flaming") == false)
        {
            flameObj.SetActive(false);
        }

    }


    void OverlapCapsule()
    {
        LayerMask layer = LayerMask.GetMask("Enemy");
        if (Input.GetKey(KeyCode.Q))
        {
            timer += Time.deltaTime;

            if (timer >= tickTime)
            {

                foreach (Collider c in Physics.OverlapCapsule(flameObj.transform.position, flameAim.transform.position, flameRadius, layer))
                {
                    print("hej");
                    GameObject enemy = c.gameObject;
                    if (c.gameObject != null)
                    {
                        Health enemyHealth = enemy.GetComponent<Health>();
                        print("step 2");
                        enemyHealth.TakeDamage(flameDamage);
                    }

                }
                timer = 0;
            }
        }


    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(flameObj.transform.position, flameAim.position);
        Gizmos.DrawWireSphere(flameAim.position, flameRadius);
        Gizmos.DrawWireSphere(flameObj.transform.position, flameRadius);
    }


}
