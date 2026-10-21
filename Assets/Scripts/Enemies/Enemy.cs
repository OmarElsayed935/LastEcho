using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D RB {get;private set;}
    public EnemyConfig Config;
    public Enemy_Sense Senses{get; private set;}
    public StateMachine StateMachine{get; private set;}

    private void Awake(){
        RB = GetComponent<Rigidbody2D>();
        StateMachine = new StateMachine();
        Senses = GetComponent<Enemy_Sense>();
    }

    public void Start(){
        StateMachine.Initialize(new Patrol(this));
    }

    private void Update() => StateMachine.CurrentState?.Update();
    private void FixedUpdate() => StateMachine.CurrentState?.FixedUpdate();
}
