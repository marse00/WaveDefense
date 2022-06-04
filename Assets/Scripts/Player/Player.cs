using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 4;
    public int health = 4;
    // Start is called before the first frame update
    void Start()
    {
        print(health);
        print(this.health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getAttacked(int damage)
    {
        print(this.health);
        print(damage);

        this.health -= damage;
        if (this.health <= 0) {
            die();
        }
    }

    void die()
    {
        Destroy(this.gameObject);
    }
}
