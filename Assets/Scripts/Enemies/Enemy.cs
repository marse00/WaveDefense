using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getAttacked(int damage) {
        /**/
        this.health -= damage;
        if(health <= 0) {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
