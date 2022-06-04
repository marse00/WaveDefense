using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float speed;
    public int damage;
    public GameObject impactEffect;
    void OnTriggerEnter2D(Collider2D receiver) 
    {
        if(receiver.tag == "Player") 
        {
            return;
        } 
        else 
        {

            Enemy victim = receiver.GetComponent<Enemy>();
            if(victim)
            {
                victim.getAttacked(damage);
            }
            
            Instantiate(impactEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
