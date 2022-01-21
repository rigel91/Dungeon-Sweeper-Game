using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    private int bulletSpeed;    
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
        //Vector3 move = transform.rotation * Vector3.forward;
        //rb.velocity = move * bulletSpeed;
        rb.MovePosition(rb.position * bulletSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("here?");
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
