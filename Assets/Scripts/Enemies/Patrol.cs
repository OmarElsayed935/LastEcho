using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    public Patrol(Enemy enemy) : base(enemy) { }


    public override void FixedUpdate(){
        if (senses.IsHittingWall() || senses.IsAtCliff()){
            Debug.Log("I found a Cliff");
            return;
        }
        rb.velocity = new Vector2(config.patrolSpeed, rb.velocity.y);
    }
}
