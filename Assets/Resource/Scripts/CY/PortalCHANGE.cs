using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PortalCHANGE : MonoBehaviour
{
    public PortalCHANGE pairedPortal;
    public bool isTeleporting;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTeleporting)
        {
            if (pairedPortal != null) { pairedPortal.TeleportObject(other); }
          
        }
        isTeleporting = false;
    }

    public void TeleportObject(Collider2D other)
    {
        isTeleporting = true;
        other.transform.position = transform.position;
    }
}