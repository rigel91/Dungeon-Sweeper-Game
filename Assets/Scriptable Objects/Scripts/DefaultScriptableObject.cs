using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Scriptable Object/Items/Default")]
public class DefaultScriptableObject : ItemInfoScriptableObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
