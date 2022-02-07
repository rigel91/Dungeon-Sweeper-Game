using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICraft : MonoBehaviour
{
    //make this class a Singleton since we only need one of this object
    private static UICraft _instance;
    public static UICraft Instance { get { return _instance; } }
    
    //list of gameobjects to craft
    public List<ItemInfoScriptableObject> table = new List<ItemInfoScriptableObject>();

    private void Awake()
    {
        //Singleton, or destroy object if more than one
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    private void Update()
    {
        CheckForCraftableItem();
    }

    private void CheckForCraftableItem()
    {
        
    }

    public void AddItem(ItemInfoScriptableObject item)
    {
        if (table.Count >= 5)
        {
            Debug.Log("Cant add");
        }
        else
        {
            Debug.Log(item.itemName);
            table.Add(item);
        }        
    }

    public void RemoveItem(ItemInfoScriptableObject item)
    {
        table.Remove(item);
        Debug.Log("Remove " + item.itemName + " from list");
    }
}
