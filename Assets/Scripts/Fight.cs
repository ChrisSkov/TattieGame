using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] float damage = 1f;
    [SerializeField] Transform swordAim;
    [SerializeField] float offset = 1f;
    [SerializeField] float radius = 1f;
    [SerializeField] GameObject bloodEffect;
    public float timeSinceLastAttack = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AttackBehavior();
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
}
