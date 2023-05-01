using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouchPlayerH : MonoBehaviour
{
    public Animator animator;
    public GameObject dialogueBox; // 将文字弹窗GameObject拖到这里

    private void Start()
    {
        dialogueBox.SetActive(false); // 隐藏文字弹窗
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 确保玩家角色具有“Player”标签
        {
            animator.SetBool("IsTouched", true);
            dialogueBox.SetActive(true); // 显示文字弹窗
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsTouched", false);
            dialogueBox.SetActive(false); // 隐藏文字弹窗
        }
    }
}
