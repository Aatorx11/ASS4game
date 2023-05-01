using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrOverCHANGE : MonoBehaviour
{
    private bool isActive;
    public Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
}
