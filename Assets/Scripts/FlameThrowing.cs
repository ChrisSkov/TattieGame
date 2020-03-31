using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowing : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Transform flameAim;
    [SerializeField] GameObject flameObj;
    [Header("Damage")]
    [SerializeField] float flameDamage = 10f;
    [SerializeField] float tickTime = 0.2f;
    [SerializeField] float flameRadius = 3f;
    [SerializeField] float attackToFlameThreshold = .6f;
    Animator anim;
    [Header("Timer")]
    [SerializeField] float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        flameObj.SetActive(false);
    }
    void Update()
    {
        OverlapCapsule();
        if(anim.GetBool("Flaming") && anim.GetBool("canFlame") == false)
        {
            StopFlame();
        }
    }
    void ActivateFlame()
    {
        if (anim.GetBool("Flaming"))
        {
            flameObj.SetActive(true);
        }
    }

    public void OverlapCapsule()
    {
        LayerMask layer = LayerMask.GetMask("Enemy");
        if (Input.GetKey(KeyCode.Q) && GetComponent<Fight>().timeSinceLastAttack > attackToFlameThreshold && anim.GetBool("canFlame"))
        {
            anim.SetBool("Flaming", true);
            timer += Time.deltaTime;
            foreach (Collider c in Physics.OverlapCapsule(flameObj.transform.position, flameAim.transform.position, flameRadius, layer))
            {
                print("hej");
                GameObject enemy = c.gameObject;
                if (c.gameObject != null && timer >= tickTime)
                {
                    Health enemyHealth = enemy.GetComponent<Health>();
                    print("step 2");
                    enemyHealth.TakeDamage(flameDamage);
                    if (c.gameObject.CompareTag("chicken"))
                    {
                        c.gameObject.GetComponent<ChickenBehavior>().SpawnChickenLeg();
                    }
                    timer = 0;
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            StopFlame();
        }
    }

    public void StopFlame()
    {
        anim.SetBool("Flaming", false);
        flameObj.SetActive(false);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(flameObj.transform.position, flameAim.position);
        Gizmos.DrawWireSphere(flameAim.position, flameRadius);
        Gizmos.DrawWireSphere(flameObj.transform.position, flameRadius);
    }


}
