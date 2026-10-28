using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action<Vector2> OnDamaged;
    public event Action OnDeath;
    public int health;
    public int maxHealth = 100;

    private void Start(){
        health = maxHealth;
    }

    public void ChangeHealth(int amount, Vector2 sourcePosition){
        health += amount;

        if (health > maxHealth) health = maxHealth;
        else if (health <= 0);
        else if (amount < 0) OnDamaged?.Invoke(sourcePosition);
    }
}
