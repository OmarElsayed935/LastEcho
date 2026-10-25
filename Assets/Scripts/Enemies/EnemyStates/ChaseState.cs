using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    
    

    protected override string AnimBoolName => "isRunning";

    public ChaseState(Enemy enemy) : base(enemy){}

    public override void FixedUpdate(){
        Debug.Log("Chasing");
        rb.velocity = Vector2.zero;
    }
}
