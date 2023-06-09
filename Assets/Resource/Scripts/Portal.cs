using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Portal : MonoBehaviour
{
    public Portal pairedPortal;
    public bool isTeleporting;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTeleporting)
        {
            pairedPortal.TeleportObject(other);
        }
        isTeleporting = false;
    }

    public void TeleportObject(Collider2D other)
    {
        isTeleporting = true;
        other.transform.position = transform.position;
    }
}