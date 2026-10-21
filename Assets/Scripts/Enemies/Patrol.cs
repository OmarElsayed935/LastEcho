using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    public Patrol(Enemy enemy) : base(enemy) { }


    public override void FixedUpdate(){
        if (senses.IsHittingWall() || senses.IsAtCliff()){
            enemy.Flip();
            return;
        }
        rb.velocity = new Vector2(config.patrolSpeed * enemy.FacingDirection, rb.velocity.y);
    }
}
