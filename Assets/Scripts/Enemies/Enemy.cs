using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    public int FacingDirection{get;private set;} = 1;

    //Components
    public Rigidbody2D RB {get;private set;}
    public Animator Anim {get;private set;}
    public EnemyConfig Config;
    public Enemy_Sense Senses{get; private set;}
    public StateMachine StateMachine{get; private set;}
    protected StateMachine stateMachine;

    public State(Enemy enemy){
            RB = enemy.RB;
            Anim = enemy.Anim;
            Config = enemy.Config;
            Senses = enemy.Senses;
            this.enemy = enemy;
            stateMachine = enemy.StateMachine;
    }

    private void Awake(){
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        StateMachine = new StateMachine();
        Senses = GetComponent<Enemy_Sense>();
    }

    public void Start(){
        StateMachine.Initialize(new Patrol(this));
    }

    private void Update() => StateMachine.CurrentState?.Update();
    private void FixedUpdate() => StateMachine.CurrentState?.FixedUpdate();

    public void Flip(){
        FacingDirection *= -1;

        Vector3 scale = transform.localScale;
        scale.x = FacingDirection;
        transform.localScale = scale;
    }
}
