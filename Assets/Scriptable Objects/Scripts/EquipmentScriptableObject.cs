using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Scriptable Object/Items/Equipment")]
public class EquipmentScriptableObject : ItemInfoScriptableObject
{
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
