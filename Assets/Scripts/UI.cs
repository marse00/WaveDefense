using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private int playerHealth;
    private int maxPlayerHealth;

    public Image[] eraser;
    public Sprite full;
    public Sprite empty;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Player>().health;
        maxPlayerHealth = player.GetComponent<Player>().maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<Player>().health;
        int uiHP = 0;
        foreach(Image point in eraser)
        {
            uiHP += 1;
            if(uiHP > playerHealth) 
            {
                point.sprite = empty;
            }else{
                point.sprite = full;
            }
        }
    }
}
