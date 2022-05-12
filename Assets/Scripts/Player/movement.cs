using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rigid_body;

    public float movement_speed;
    public float acceleration;
    public float friction;
    Vector2 velocity = Vector2.zero;
    float vertical;
    float horizontal;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {


        float delta = Time.deltaTime;
        Vector2 input_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input_vector.Normalize();
        
        if(input_vector == Vector2.zero) {
            animator.SetBool("isMoving", false);
            rigid_body.velocity = Vector2.MoveTowards(rigid_body.velocity,Vector2.zero, delta * friction);
        } else {
            animator.SetFloat("X_Input", input_vector.x);
            animator.SetFloat("Y_Input", input_vector.y); 
            animator.SetBool("isMoving", true);
            rigid_body.velocity = Vector2.MoveTowards(rigid_body.velocity, input_vector * movement_speed, acceleration * delta);
                  
        }
            

       
    }
   
}   
