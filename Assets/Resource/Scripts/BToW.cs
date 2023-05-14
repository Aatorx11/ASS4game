using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BToW : MonoBehaviour
{ 
    private bool isWhite = false; // Set initial color to black
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    public Color color1;
    public Color color2;
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();   
       
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightShift))
        {
            // Toggle color between black and white
          isWhite = !isWhite;
            if (isWhite)
            {
                spriteRenderer.color = Color.green;
            }
            else
            {
                spriteRenderer.color = Color.red;
            }
    }
}
}
