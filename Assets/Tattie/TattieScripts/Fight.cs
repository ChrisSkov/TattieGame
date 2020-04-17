using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fight : MonoBehaviour
{

    [SerializeField] float damage = 1f;
    [SerializeField] float stabRange = 3f;
    [SerializeField] float stabDamage = 1f;
    [SerializeField] Transform swordAim;
    [SerializeField] Transform stabAim;
    [SerializeField] float offset = 1f;
    [SerializeField] float radius = 1f;
    [SerializeField] GameObject bloodEffect;
    [SerializeField] AudioClip[] attackSounds;
    [SerializeField] AudioClip[] swingNoises;
    AudioSource source;
    int randomSoundClip;
    public float timeSinceLastAttack = Mathf.Infinity;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(stabAim.transform.position, transform.TransformDirection(Vector3.forward) * stabRange, Color.yellow);
    }
    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }
    //Animation event for AOE Attack
    void AOEMeleeAttack()
    {
        bool hasPlayed = false;
        LayerMask layer = LayerMask.GetMask("Enemy");
        foreach (Collider c in Physics.OverlapSphere(swordAim.position, radius, layer))
        {
            if (c.gameObject != null && c.gameObject.tag == ("Enemy"))
            {
                if (!hasPlayed)
                {
                    source.PlayOneShot(attackSounds[0]);
                    hasPlayed = true;
                }
                Vector3 offSet = new Vector3(0, offset, 0);
                var bloodClone = Instantiate(bloodEffect, c.ClosestPoint(swordAim.transform.position + offSet), swordAim.transform.rotation);
                c.gameObject.GetComponent<Health>().TakeDamage(GetDamage());
            }
        }

    }
    void SwordSwingSound()
    {
        source.PlayOneShot(attackSounds[1]);
    }

    void SwingNoise()
    {
        source.PlayOneShot(swingNoises[Random.Range(0, swingNoises.Length)]);

    }
    //Animation event for stab
    void SingleTargetAttack()
    {
        LayerMask layer = LayerMask.GetMask("Enemy");
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(stabAim.transform.position, transform.TransformDirection(Vector3.forward), out hit, stabRange, layer))
        {
                source.PlayOneShot(attackSounds[0]);
                Vector3 offSet = new Vector3(0, offset, 0);

                hit.rigidbody.gameObject.GetComponent<Health>().TakeDamage(damage);
                var bloodClone = Instantiate(bloodEffect, hit.point, hit.rigidbody.gameObject.transform.rotation);
            
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(swordAim.position, radius);
    }


}
