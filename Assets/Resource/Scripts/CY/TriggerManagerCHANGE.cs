using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManagerCHANGE : MonoBehaviour
{
    public GameObject targetObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "GameOver")
        {
            GameOver();
            MainUIManagerCHANGE.Instance.ShowGamePanel(false);
        }
        if (this.tag == "Win" && collision.gameObject.tag == "Player")
        {
            GameOver();
            MainUIManagerCHANGE.Instance.ShowGamePanel(true);
            if (targetObject.TryGetComponent<PlayerControllerCHANGE>(out PlayerControllerCHANGE playerController))
            {
                playerController.isActive = false;
            }
        }
    }

    public void GameOver()
    {
        targetObject.SetActive(false);
    }
}
