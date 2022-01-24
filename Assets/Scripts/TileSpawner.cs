using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    //spawn in tiles
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private GameObject[] tiles;

    //clue images
    [SerializeField]
    private GameObject clue1;
    [SerializeField]
    private GameObject clue2;
    [SerializeField]
    private GameObject clue3;
    [SerializeField]
    private GameObject clue4;

    //row and column
    [SerializeField]
    private int xRow;
    [SerializeField]
    private int zRow;

    //list for guesses and total list
    private List<int> finalList = new List<int>();
    private List<int> playerList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        ClearClues();
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
            //checks to see if the guesses are in the correct spot or is contained
            List<string> clueList = new List<string>();
            for (int i = 0; i < finalList.Count; i++)
            {
                if (playerList[i] == finalList[i])
                {
                    clueList.Add("Correct position");
                }
                else if (playerList[i] != finalList[i] && finalList.Contains(playerList[i]))
                {
                    clueList.Add("Contains but not same position");
                }
            }            
            for (int i = 0; i < clueList.Count; i++)
            {
                Debug.Log(clueList[i].ToString());
            }
            clueList.Clear();

            //compares the lists and checks to see if player is winner or not
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

    private void ClearClues()
    {
        clue1.SetActive(false);
        clue2.SetActive(false);
        clue3.SetActive(false);
        clue4.SetActive(false);
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
