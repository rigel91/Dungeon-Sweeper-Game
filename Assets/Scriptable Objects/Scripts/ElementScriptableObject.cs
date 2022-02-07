using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element Object", menuName = "Scriptable Object/Items/Element")]
public class ElementScriptableObject : ItemInfoScriptableObject
{
    public void Awake()
    {
        type = ItemType.Element;
    }
}
