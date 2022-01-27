using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    private int bulletSpeed;
    [SerializeField]
    private int damagePerBullet;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damagePerBullet);
            Destroy(this.gameObject);
        }
    }
}
