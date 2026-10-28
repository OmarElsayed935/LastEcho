using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sense : MonoBehaviour
{
    public EnemyConfig config;
    public Transform groundCheck;
    public Transform wallCheck;
    public Enemy enemy;
    public Transform attackPoint;

    private void Awake()
    {
        if (enemy == null) enemy = GetComponent<Enemy>();
    }

    private void OnDrawGizmos()
    {
        if (config == null || groundCheck == null || wallCheck == null) return;

        // Ground check
        Gizmos.color = Color.green;
        if (groundCheck != null)
        {
            Gizmos.DrawWireSphere(groundCheck.position, 0.05f);
            Gizmos.DrawLine(groundCheck.position,
                groundCheck.position + Vector3.down * config.groundCheckDistance);
        }

        // Wall checks
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(wallCheck.position, 0.05f);
        Gizmos.DrawLine(wallCheck.position,
            wallCheck.position + Vector3.right * config.wallCheckDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(wallCheck.position,
            wallCheck.position + Vector3.left * config.wallCheckDistance);

        //chase check
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, config.chaseRange);

        //melee check
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(attackPoint.position, config.meleeRange);
    }

    public bool IsAtCliff() => !Physics2D.Raycast(groundCheck.position,Vector2.down,config.groundCheckDistance,config.groundLayer);        
    public bool IsHittingWallright() => Physics2D.Raycast(wallCheck.position,Vector2.right,config.wallCheckDistance,config.wallLayer);
    public bool IsHittingWallleft() => Physics2D.Raycast(wallCheck.position,Vector2.left,config.wallCheckDistance,config.wallLayer);
    
    public bool IsInMeleeRange(Transform target){
        if (!target) return false;
        float distance = Vector2.Distance(target.position, attackPoint.position);
        return distance <= config.meleeRange;
    }

    public Transform GetChaseTarget(){
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, config.chaseRange, config.targetLayer);

        if (hits.Length == 0) return null;
        return hits[0].transform;
    }
}
