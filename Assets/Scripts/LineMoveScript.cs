using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMoveScript : MonoBehaviour
{
    public float linearSpeed;
    private float cameraWidth;

    void Start()
    {
        Camera orthoCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        cameraWidth = 2.0f * orthoCam.orthographicSize * (float) Screen.width / (float) Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1.0f * linearSpeed * Time.deltaTime, 0.0f, 0.0f);
        
        if(Mathf.Abs(transform.position.x) > 4 * 3.4f * transform.localScale.x){
            transform.position = new Vector3(0.0f, transform.position.y, 0.0f);
        }
    }
}
