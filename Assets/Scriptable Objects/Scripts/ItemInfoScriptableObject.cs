using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Element,
    Equipment,
    Default
}

//[CreateAssetMenu(menuName = "Scriptable Object/New Item")]
public abstract class ItemInfoScriptableObject : ScriptableObject
{
    public string itemName;
    //public Image itemImage;    
    public Color itemColor;

    public ItemType type;
    [TextArea(15,20)]
    public string description;
}
