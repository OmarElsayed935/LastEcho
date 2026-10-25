using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    
    public Transform target;
    protected override string AnimBoolName => "isIdle";
    public IdleState(Enemy enemy) : base(enemy){}

    
    public override void Enter(){
        base.Enter();
        rb.velocity = Vector2.zero;
    }
    
    public override void FixedUpdate(){
        target = senses.GetChaseTarget();
        if(!target){
            stateMachine.ChangeState(new Patrol(enemy));
            return;
        }

        enemy.FaceTarget(target);

        float distance = Mathf.Abs(target.position.x - enemy.transform.position.x);
        if (distance <= config.turnThreshold)
        {
            rb.velocity = Vector2.zero;
            return;
        }


        if(senses.IsHittingWallright() || senses.IsAtCliff() ||senses.IsHittingWallleft()){
            rb.velocity = Vector2.zero;
        }
        stateMachine.ChangeState(new ChaseState(enemy));
    }

    public override void Exit(){
        base.Exit();
        rb.velocity = Vector2.zero;
    }
}
