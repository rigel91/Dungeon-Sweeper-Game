using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyScriptableObject enemySO;

    private float health;

    public Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        health = enemySO.health;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            agent.SetDestination(target.position);
        }

        if (health <= 0)
        {
            //destroy enemy
            Debug.Log("Destroy Enemy");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
