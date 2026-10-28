using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    protected override string AnimBoolName => "isWalking";
    private const float FLIP_COOLDOWN = 0.15f;   // tune this
    private float flipTimer;

    public Patrol(Enemy enemy) : base(enemy) { }

    public override void FixedUpdate()
    {
        if (senses.GetChaseTarget() != null)
        {
            stateMachine.ChangeState(new ChaseState(enemy));
            return;
        }
        if (flipTimer > 0f)
            flipTimer -= Time.fixedDeltaTime;

        // Only check the wall in the direction we're actually walking.
        bool wallAhead = enemy.FacingDirection > 0
            ? senses.IsHittingWallright()
            : senses.IsHittingWallleft();

        if (flipTimer <= 0f && (wallAhead || senses.IsAtCliff()))
        {
            enemy.Flip();
            flipTimer = FLIP_COOLDOWN;
        }

        rb.velocity = new Vector2(config.patrolSpeed * enemy.FacingDirection, rb.velocity.y);
    }
}
