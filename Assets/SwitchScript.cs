﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
