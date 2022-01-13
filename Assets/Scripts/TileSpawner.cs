using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private GameObject[] tiles;
    [SerializeField]
    private int xRow;
    [SerializeField]
    private int zRow;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < xRow; i++)
        {
            for (int j = 0; j < zRow; j++)
            {
                Instantiate(tiles[Random.Range(0, tiles.Length)], new Vector3(transform.position.x + j * 10, 0, transform.position.z + i * 10), Quaternion.Euler(new Vector3(0, 0, 0)), parent.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
