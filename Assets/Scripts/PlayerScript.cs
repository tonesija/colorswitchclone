using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;

    ParticleSystem ps;
    public float jumpForce;

    public float gravityScale;

    public event Action OnScorePickup;  
    public event Action OnPlayerDeath; 

    string playerColor;
    private string oldPlayerColor;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        ps = GetComponent<ParticleSystem>();

        string[] colors = {"y", "b", "p", "v"};
        int randomColor = UnityEngine.Random.Range(0, 4);
        
        playerColor = colors[randomColor];
        
        gameObject.GetComponent<SpriteRenderer>().color = GetColorFromString(playerColor);

        oldPlayerColor = playerColor;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            rb.velocity = new Vector2(0f, jumpForce);
            rb.gravityScale = gravityScale;
        }

        if(!oldPlayerColor.Equals(playerColor)){

            oldPlayerColor = playerColor;


            gameObject.GetComponent<SpriteRenderer>().color = GetColorFromString(playerColor);
            Debug.Log(GetColorFromString(playerColor) + " " + gameObject.GetComponent<SpriteRenderer>().color);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;
        
        if (tag.Equals("score")){
            if(OnScorePickup != null) OnScorePickup();
            PlayerPickupScore();
        }else if (tag.Equals("switch")){
            
            string[] colors = {"y", "b", "p", "v"};
            int randomColor = UnityEngine.Random.Range(0, 4);

            if(colors[randomColor].Equals(playerColor)){
                playerColor = colors[(randomColor+1)%4];
            }else{
                playerColor = colors[randomColor];
            }

        }else if(!tag.Equals(playerColor)){
            if(OnPlayerDeath != null) OnPlayerDeath();
            PlayerDied();
            Time.timeScale = 0.0f;
            return;
        }
    }

    Color GetColorFromRGBA(int r, int g, int b, int a){
        return new Color((float) r / 255.0f, (float)g / 255.0f, (float) b / 255.0f, (float) a / 255.0f);
    }

    Color GetColorFromString(string colorName){
        Color returnColor;
        
        if(colorName.Equals("y")){
            returnColor = GetColorFromRGBA(250, 225, 0, 255);
        }else if(colorName.Equals("b")){
            returnColor = GetColorFromRGBA(50, 219, 240, 255);
        }else if(colorName.Equals("p")){
            returnColor = GetColorFromRGBA(255, 1, 129, 255);
        }else if(colorName.Equals("v")){
            returnColor = GetColorFromRGBA(144, 13, 255, 255);
        }else{
            returnColor = GetColorFromRGBA(255, 0, 0, 255);
        }

        return returnColor;
    }

    void PlayerDied(){
        
    }

    void PlayerPickupScore(){
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = new Color(1, 1, 1);
        emitParams.startSize = 0.12f;
        
        ps.Emit(emitParams, 12);
    }

    
}
