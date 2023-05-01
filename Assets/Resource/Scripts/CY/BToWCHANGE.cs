using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BToWCHANGE : MonoBehaviour
{
  

    private Renderer controlledObjectRenderer;
    private Collider2D controlledObjectCollider;
    private bool isShow=false;
    void Start()
    {
    
      
        controlledObjectRenderer = this.GetComponent<Renderer>();
        controlledObjectCollider = this.GetComponent<Collider2D>();
        controlledObjectRenderer.enabled = false;
        controlledObjectCollider.enabled = false;
        controlledObjectRenderer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        // Toggle color between black and white
    //        isWhite = !isWhite;
    //        if (isWhite)
    //        {
    //            spriteRenderer.color = Color.white;
    //        }
    //        elseX`
    //        {
    //            spriteRenderer.color = Color.black;
    //        }
    //    }
    //}
    public void ChangeHideAndShow()
    {
        controlledObjectRenderer.enabled = !controlledObjectRenderer.enabled;
        controlledObjectCollider.enabled = !controlledObjectCollider.enabled;
        if (isShow)
        {
            isShow = false;
            controlledObjectRenderer.gameObject.SetActive(false);
        }
        else
        {
            isShow = true;
            controlledObjectRenderer.gameObject.SetActive(true);
        }
    }
}
