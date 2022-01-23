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

    private List<int> finalList = new List<int>();
    private List<int> playerList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateSequence();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerSequence();
    }

    private void GenerateSequence()
    {
        List<int> tempTiles = new List<int>();
        for(int i = 0; i < tiles.Length; i++)
        {
            tempTiles.Add(i);
            //Debug.Log(tempTiles[i]);
        }

        while (tempTiles.Count != 0)
        {
            int randomNum = Random.Range(0, tempTiles.Count);
            Debug.Log(tempTiles[randomNum]);
            finalList.Add(tempTiles[randomNum]);
            tempTiles.Remove(tempTiles[randomNum]);            
        }
    }

    public void BlueButton()
    {
        Debug.Log("Blue: 0");
        playerList.Add(0);
    }
    public void RedButton()
    {
        Debug.Log("Red: 1");
        playerList.Add(1);
    }
    public void YellowButton()
    {
        Debug.Log("Yellow: 2");
        playerList.Add(2);
    }
    public void GreenButton()
    {
        Debug.Log("Green: 3");
        playerList.Add(3);
    }

    private void CheckPlayerSequence()
    {
        if (playerList.Count == finalList.Count)
        {            
            for (int i = 0; i < finalList.Count; i++)
            {
                if (playerList[i] != finalList[i])
                {
                    Debug.Log("Lose");
                    playerList.Clear();
                    return;
                }
            }
            Debug.Log("Win");
            playerList.Clear();
            return;
        }       
    }

    private void SpawnTiles()
    {
        for (int i = 0; i < xRow; i++)
        {
            for (int j = 0; j < zRow; j++)
            {
                Instantiate(tiles[Random.Range(0, tiles.Length)], new Vector3(transform.position.x + j * 10, 0, transform.position.z + i * 10), Quaternion.Euler(new Vector3(0, 0, 0)), parent.transform);
            }
        }
    }
}
