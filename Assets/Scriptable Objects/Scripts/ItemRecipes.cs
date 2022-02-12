using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Recipes")]
public class ItemRecipes : ScriptableObject
{
    public List<ItemInfoScriptableObject> recipe = new List<ItemInfoScriptableObject>();
    public ItemInfoScriptableObject result;
}
