using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WToBCHANGE : MonoBehaviour
{
   // private bool isWhite = false; // Set initial color to black
    // Start is called before the first frame update
  //  private SpriteRenderer spriteRenderer;
    private Renderer controlledObjectRenderer;
    private Collider2D controlledObjectCollider;
    private bool isShow = true;
    void Start()
    {
       // spriteRenderer = GetComponent<SpriteRenderer>();
        controlledObjectRenderer = this.GetComponent<Renderer>();
        controlledObjectCollider = this.GetComponent<Collider2D>();
        //controlledObjectRenderer.enabled = false;
        //controlledObjectCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {       
    }
    public void ChangeHideAndShow()
    {
        controlledObjectRenderer.enabled = !controlledObjectRenderer.enabled;
        controlledObjectCollider.enabled = !controlledObjectCollider.enabled;
        if (isShow)
        {
            this.gameObject.SetActive(false);
            isShow = false;
        }
        else
        {
            this.gameObject.SetActive(true);
            isShow = true;
        }
    }
}
