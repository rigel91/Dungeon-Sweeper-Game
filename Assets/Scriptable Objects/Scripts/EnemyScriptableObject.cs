using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/New Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public float health;
    public float speed;
}
