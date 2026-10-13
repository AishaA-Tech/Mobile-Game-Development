using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable Objects/Enemy", order = 1)]
public class enemyData : ScriptableObject
{
    public int health;
    public int damage;
}
