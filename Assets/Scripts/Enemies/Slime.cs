using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private Transform target;
    private bool isAggroed = false;
    private float speed = 0.15f;
    private Transform sprite;
    public bool isGrounded = true;
    public Vector3 jumpTarget;
    public float attackTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform as Transform;
        sprite = this.transform.parent.gameObject.transform;
        jumpTarget = target.position;
        this.health = 5;
        attackTimer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if((target.position - this.transform.position).magnitude < 0.5) 
        {
            isAggroed = true;
        }
        movement();
        
    }

    void OnTriggerEnter2D(Collider2D receiver) 
    {
        if(receiver.GetType() == typeof(BoxCollider2D) && receiver.tag == "Player") 
        {
            if(attackTimer <= 0)
            {
                receiver.GetComponent<Player>().getAttacked(this.damage);
                attackTimer = 1;
                print("It was called");
            }
            
        }
    }
    

    void movement() {
        if(isAggroed && !isGrounded) {
            moveTowards(jumpTarget);
        } else if(isGrounded) {
            jumpTarget = target.position; //Before jumping the enemy decides the jumping dest
                                //this prevents the enemy changing direction mid air
        }
    }

    void moveTowards(Vector3 target) 
    {
        sprite.position = Vector3.MoveTowards(sprite.position,
        target,
        speed*Time.deltaTime); // Normal movement
        return;
    }

}
