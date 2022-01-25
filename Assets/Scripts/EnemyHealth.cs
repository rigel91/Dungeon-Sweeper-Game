using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if enemys health is less than 0
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
