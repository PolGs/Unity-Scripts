using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.AI; 

public class ZAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(player.position);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
