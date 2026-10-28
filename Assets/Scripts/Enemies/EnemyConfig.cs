using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{

    [Header("General")]
    public float turnThreshold = 0.2f;

    [Header("Patrol")]
    public float patrolSpeed = 5;
    public float groundCheckDistance = .7f;
    public float wallCheckDistance = .5f;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    [Header("Chase")]
    public float chaseSpeed =7f;
    public float chaseRange = 5f;
    public LayerMask targetLayer;

    [Header("Attack")]
    public float meleeRange = .8f;
    public int meleeDamage = 12;
    public float meleeCooldown = 1;

    [Header("Damaged")]
    public float knockbackDuration = .2f;
    public float knockbackForce = 15;
}
