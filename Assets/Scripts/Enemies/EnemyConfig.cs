using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{

    public float patrolSpeed = 5;
    public float groundCheckDistance = .7f;
    public float wallCheckDistance = .5f;

    public LayerMask groundLayer;
    public LayerMask wallLayer;
    
}
