using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent zombie;
    public float attackrange = 7f;
    public Playerstats playerstats;
    private GameObject playerPosition; // A reference to the player's position

    void Start()
    {
        playerPosition = GameObject.Find("Player"); // A reference to the player's position
        playerstats.isBeingAttacked = false;
        //playerstats.health = 100f;
    }

    void Update()
    {
        zombie.SetDestination(playerPosition.transform.position);

        // If the player is within attack range, attack them
        if (Vector3.Distance(transform.position, playerPosition.transform.position) <= attackrange)
        {
            Debug.Log("Before damage");
            Debug.Log(playerstats.isBeingAttacked);
            transform.LookAt(playerPosition.transform.position);
            StartCoroutine(playerstats.TakeDamage(20f));
            //playerstats.isBeingAttacked = false;
            Debug.Log("Now in distance");
            
        }

        // If the zombie has reached its destination and is not following a path, stop moving
        if (zombie.remainingDistance <= zombie.stoppingDistance && !zombie.pathPending)
        {
            zombie.isStopped = true;
        }
        else
        {
            zombie.isStopped = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackrange);
    }
}
