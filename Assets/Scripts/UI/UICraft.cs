using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICraft : MonoBehaviour
{
    public List<GameObject> table = new List<GameObject>();


    private void Update()
    {
        CheckForCraftableItem();
    }

    private void CheckForCraftableItem()
    {
        foreach (GameObject obj in table)
        {
            if (obj.name == "Image")
            {
                //Debug.Log("Crafted");
            }
        }
    }

    public void AddItem(GameObject item)
    {
        if (table.Count >= 5)
        {
            Debug.Log("Cant add");
        }
        else
        {
            Debug.Log(item.gameObject.name);
            table.Add(item);
        }        
    }

    public void RemoveItem(GameObject item)
    {
        table.Remove(item);
        Debug.Log("Remove " + item.name + " from list");
    }
}
