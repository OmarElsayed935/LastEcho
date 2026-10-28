using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed =6f;
    [SerializeField] public float jumpPower = 12f;

    public Rigidbody2D body;
    public Animator anim;
    public bool grounded;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update(){
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);

        Vector3 scale = transform.localScale;
        if (horizontalInput > 0.01f) scale.x = Mathf.Abs(scale.x);
        else if (horizontalInput < -0.01f) scale.x = -Mathf.Abs(scale.x);
        transform.localScale = scale;

        if (Input.GetKeyDown(KeyCode.Space) && grounded) Jump();

        anim.SetBool("Run",horizontalInput != 0);

        anim.SetFloat("yVelocity",body.velocity.y);
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x,jumpPower);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground")) grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) grounded = false;
    }
}    
