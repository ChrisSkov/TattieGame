using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class AICombat : MonoBehaviour
{
    [Header("Combat")]
    [SerializeField] float damage = 10f;
    [Range(0, 1)]
    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] float attackRange = 3f;
    [SerializeField] float despawnTime = 3f;
    [SerializeField] float pointValue = 100f;

    float timeSinceLastAttack = Mathf.Infinity;

    NavMeshAgent agent;
    float attackTimer = Mathf.Infinity;
    Animator anim;
    Health health;
    Health playerHP;
    bool scoreIsUpdated = false;
    GameObject player;
    [SerializeField] Health target;

    AIMover mover;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHP = player.GetComponent<Health>();
        mover = GetComponent<AIMover>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        DeathBehavior();
        UpdateAnimator();
        TargetBehavior();
    }

    private void TargetBehavior()
    {
        if (mover.PlayerInChaseRange())
        {
            target = playerHP;
        }
        else
        {
            target = FindTarget().GetComponent<Health>();
        }
        mover.MoveToTarget(target);
        if (TargetInAttackRange())
        {
            AttackBehavior();
        }
        if (target == null) return;
    }

    void DeathBehavior()
    {
        if (health.IsDead() && !scoreIsUpdated)
        {
            agent.isStopped = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.detectCollisions = false;
            player.gameObject.GetComponent<Score>().score += pointValue;
            scoreIsUpdated = true;
            Destroy(gameObject, despawnTime);
            return;
        }
    }

    //Animation event
    void Hit()
    {
        if (target == null) { return; }
        if (!TargetInAttackRange())
        {
            return;
        }
        target.TakeDamage(damage);

    }
    bool TargetInAttackRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) < attackRange;

    }

    private void AttackBehavior()
    {
        transform.LookAt(target.transform);
        if (timeSinceLastAttack > timeBetweenAttacks && TargetInAttackRange())
        {
            // This will trigger the Hit() event.
            TriggerAttack();
            timeSinceLastAttack = 0;
        }
        else
        {
            StopAttack();
        }
    }
    GameObject FindTarget()
    {
        GameObject[] chickens;
        chickens = GameObject.FindGameObjectsWithTag("chicken");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject chicken in chickens)
        {
            Vector3 diff = chicken.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = chicken;
                distance = curDistance;

            }
        }
        return closest;
    }
    private void StopAttack()
    {
        GetComponent<Animator>().ResetTrigger("attack");
        GetComponent<Animator>().SetTrigger("stopAttack");
    }
    private void TriggerAttack()
    {
        GetComponent<Animator>().ResetTrigger("stopAttack");
        GetComponent<Animator>().SetTrigger("attack");
    }
    private void UpdateAnimator()
    {
        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        anim.SetFloat("forwardSpeed", Mathf.Abs(speed));
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
