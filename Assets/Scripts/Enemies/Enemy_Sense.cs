using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sense : MonoBehaviour
{
    public EnemyConfig config;
    public Transform groundCheck;
    public Transform wallCheck;




    public bool IsAtCliff() => !Physics2D.Raycast(groundCheck.position,Vector2.down,config.groundCheckDistance,config.groundLayer);        
    public bool IsHittingWall() => Physics2D.Raycast(wallCheck.position,Vector2.down,config.wallCheckDistance,config.wallLayer);
}
