using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Player
{
    private Rigidbody2D rigid_body;

    public float movement_speed;
    public float acceleration;
    public float friction;
    public GameObject Projectile;
    public List<GameObject> launchPoints;
    public float projectileSpeed;
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
        movementHandler(delta);
        attackHandler(delta);

       
    }
   
   void movementHandler(float delta) 
   {
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
   
   void attackHandler(float delta) 
   {
        if(Input.GetMouseButtonDown(0)) 
        {
            attack1();
        } else if(Input.GetMouseButtonDown(1))
        {
            
        }
        
   }

    void attack1() 
    {
        Camera camera = Camera.main;
        Vector3 aim = camera.ScreenToWorldPoint(Input.mousePosition);
        Transform origin;
        GameObject projectileInstance;
        animator.SetFloat("X_Mouse",aim.x-rigid_body.position.x);
        animator.SetFloat("Y_Mouse",aim.y-rigid_body.position.y);
        animator.SetTrigger("isAttack1");

        origin = calculateLaunchPoint(aim);
        projectileInstance = Instantiate(Projectile,origin);
        Rigidbody2D projectileRB = projectileInstance.GetComponent<Rigidbody2D>();
        Vector3 direction = (aim - rigid_body.transform.position);
        direction = direction.normalized;
        projectileRB.velocity = new Vector2(direction.x, direction.y).normalized * projectileSpeed;
        
        //Set rotation based on velocity direction
        projectileRB.transform.LookAt(projectileRB.transform.position + direction);
        float angle = Mathf.Atan2(projectileRB.velocity.y, projectileRB.velocity.x) * Mathf.Rad2Deg;
        projectileRB.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    Transform calculateLaunchPoint(Vector3 aim) {
        Transform result = null;
        float min = float.MaxValue;
        foreach(GameObject launchPoint in launchPoints)
        {
            if(min > distance2D(aim,launchPoint.transform.position)) 
            {
                min = distance2D(aim,launchPoint.transform.position);
                result = launchPoint.transform;
            }
        }
        
        return result;
   }

   float distance2D(Vector2 a, Vector2 b)
   {
        return Mathf.Sqrt(Mathf.Pow(a.x-b.x,2) + Mathf.Pow(a.y-b.y,2));

   }
}   
