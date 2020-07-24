using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;

    public event Action OnScorePickup;  
    public event Action OnPlayerDeath; 

    string playerColor;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerColor = "y";
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            rb.velocity = new Vector2(0f, jumpForce);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;
        
        if(!tag.Equals(playerColor)){
            if(OnPlayerDeath != null) OnPlayerDeath();
            Destroy(this.gameObject);
            return;
        } else if (tag.Equals("score")){
            if(OnScorePickup != null) OnScorePickup();
        }
    }
}
