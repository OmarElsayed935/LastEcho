using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    
    public Transform target;
    protected override string AnimBoolName => "isRunning";
    public ChaseState(Enemy enemy) : base(enemy){}

    public override void FixedUpdate(){

        //Check for a target
        target = senses.GetChaseTarget();
        if(!target){
            stateMachine.ChangeState(new Patrol(enemy));
            return;
        }

        enemy.FaceTarget(target);

        //Check if we can attack

        if (senses.IsInMeleeRange(target) && combat.CanMeleeAttack()){
            stateMachine.ChangeState(new MeleeAttack(enemy));
            return;
        }

        //Check if we have reached our target
        float distance = Mathf.Abs(target.position.x - enemy.transform.position.x);
        if (distance <= config.turnThreshold)
        {
            stateMachine.ChangeState(new IdleState(enemy));
            return;
        }

        //Check for obstacles
        if(senses.IsHittingWallright() || senses.IsAtCliff() ||senses.IsHittingWallleft()){
            stateMachine.ChangeState(new IdleState(enemy));
            return;
        }

        //Move toward the target
        rb.velocity = new Vector2(config.chaseSpeed * enemy.FacingDirection, rb.velocity.y);
    }

    public override void Exit(){
        base.Exit();
        rb.velocity = Vector2.zero;
    }
}
