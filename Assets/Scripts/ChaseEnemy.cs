using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ChaseEnemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
