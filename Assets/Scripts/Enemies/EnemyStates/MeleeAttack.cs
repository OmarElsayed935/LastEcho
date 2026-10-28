using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : State
{
    protected override string AnimBoolName => "isAttacking";
    
    public MeleeAttack(Enemy enemy) : base (enemy){}

    public override void Enter(){
        base.Enter();

        rb.velocity = Vector2.zero;

    }

    public override void OnAnimationFinished(){
        stateMachine.ChangeState(new IdleState(enemy));
    }
}
