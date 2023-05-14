using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WToBYC : MonoBehaviour
{ 
    private bool isWhite = false; // Set initial color to black
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();   
       
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.LeftShift)  || Input.GetKeyDown(KeyCode.RightShift))
        {
            // Toggle color between black and white
          isWhite = !isWhite;
            if (isWhite)
            {
                spriteRenderer.color = new Color32(0x4A, 0xC5, 0xFF, 0xFF);
            }
            else
            {
                spriteRenderer.color = new Color(0.42f, 0.20f, 0.45f, 1f);
            }
    }
}
}
