using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    bool isDead = false;
    public bool canAttack = true;
    
    public float turnSpeed = 5f;
    public float DMGAmount = 10f;
    public float attackTime = 2f;

    public float lookRadius = 10;

    public Transform[] waypoints;
    public int speed;
    private int waypointIndex;
    private float dist;

    private EnemyAnimation Enemy_Anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        Enemy_Anim = GetComponent<EnemyAnimation>();        
    }

    private void Update()
    {   
        float distance = Vector3.Distance(player.position, transform.position);
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        if (distance <= lookRadius && !isDead)
        {          
            chasePlayer();

        }if (distance <= agent.stoppingDistance)
        {
            if (canAttack && !Player_Health.playerhealth.isDie)
            {
                attackPlayer();
            }
            else if (!Player_Health.playerhealth.isDie)
            {
                DisableEnemy();
            }
        }else if(dist < 1f)
        {    
            IncreaseIndex();           
        }
        
        Patrol();
    }

    void Patrol()
    {        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Enemy_Anim.Walk(true);      
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex>=waypoints.Length)
        {
            waypointIndex=0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void chasePlayer()
    {
        Enemy_Anim.Run(true);
        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.SetDestination(player.position);    
    }

    void attackPlayer()
    {
        Enemy_Anim.Attack();
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);        
        StartCoroutine(Attacktime());
    }

    void DisableEnemy()
    {    
        canAttack = false;
    }


    IEnumerator Attacktime()
    {
        
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        Player_Health.playerhealth.DamagePlayer(DMGAmount);
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
    }
}
