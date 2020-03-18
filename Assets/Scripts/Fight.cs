using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] float damage = 1f;
    [SerializeField] float stabDamage = 1f;
    [SerializeField] Transform swordAim;
    [SerializeField] Transform stabAim;
    [SerializeField] float offset = 1f;
    [SerializeField] float radius = 1f;
    [SerializeField] float stabRange = 3f;
    [SerializeField] GameObject bloodEffect;
    public float timeSinceLastAttack = Mathf.Infinity;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackBehavior();
        Debug.DrawRay(stabAim.transform.position, transform.TransformDirection(Vector3.forward) * stabRange, Color.yellow);

    }
    private void AttackBehavior()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (timeSinceLastAttack > timeBetweenAttacks && Input.GetKey(KeyCode.Mouse0))
        {
            // This will trigger the Hit() event.
            TriggerAttack();
            timeSinceLastAttack = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopAttack();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            TriggerAttackHeavy();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopAttackHeavy();
        }
        if (Input.GetKey(KeyCode.Z))
        {
          
            TriggerStab();
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            StopStab();
        }

    }


    void Hit()
    {
        LayerMask layer = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(swordAim.position, radius, layer))
        {
            if (c.gameObject != null && c.gameObject.tag == ("Enemy"))
            {
                Vector3 offSet = new Vector3(0, offset, 0);
                var bloodClone = Instantiate(bloodEffect, c.ClosestPoint(swordAim.transform.position + offSet), swordAim.transform.rotation);
                c.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }

    }

    void Stab()
    {
        LayerMask layer = LayerMask.GetMask("Enemy");
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(stabAim.transform.position, transform.TransformDirection(Vector3.forward), out hit, stabRange, layer))
        {
            Vector3 offSet = new Vector3(0, offset, 0);

            hit.rigidbody.gameObject.GetComponent<Health>().TakeDamage(stabDamage);
            var bloodClone = Instantiate(bloodEffect, hit.point, hit.rigidbody.gameObject.transform.rotation);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(swordAim.position, radius);
    }
    private void StopAttack()
    {
        GetComponent<Animator>().SetBool("attacking", false);
    }
    private void TriggerAttack()
    {
        GetComponent<FlameThrowing>().StopFlame();
        GetComponent<Animator>().SetBool("attacking", true);
    }

    private void StopAttackHeavy()
    {
        GetComponent<Animator>().ResetTrigger("attack");
        GetComponent<Animator>().SetTrigger("stopAttack");
    }
    private void TriggerAttackHeavy()
    {
        GetComponent<Animator>().ResetTrigger("stopAttack");
        GetComponent<Animator>().SetTrigger("attack");
    }
    private void StopStab()
    {
        GetComponent<Animator>().ResetTrigger("stab");
        GetComponent<Animator>().SetTrigger("stopStab");
    }
    private void TriggerStab()
    {
        
        GetComponent<Animator>().ResetTrigger("stopStab");
        GetComponent<Animator>().SetTrigger("stab");
    }
}
