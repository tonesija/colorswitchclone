using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerTransform;

    public float playerOffset;

    string playerColor;

    
    void Update()
    {
        if(playerTransform != null && playerTransform.position.y + playerOffset > transform.position.y){
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + playerOffset, transform.position.z);
        }
    }

}
