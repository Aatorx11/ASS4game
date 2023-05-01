using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
/// <summary>
/// UI�����ű�
/// </summary>
public class MainUIManagerCHANGE : MonoBehaviour
{
    public static MainUIManagerCHANGE Instance;

    /// <summary>
    /// ��ʱ
    /// </summary>
    public Text timeTxt;
    /// <summary>
    /// ��Ϸ����ҳ��
    /// </summary>
    public Transform gameOverPanel;
    /// <summary>
    /// �˳���ť
    /// </summary>
    public Button backToMain;
    /// <summary>
    /// ���水ť
    /// </summary>
    public Button restartBtn;

    /// <summary>
    /// ��ʱ-��
    /// </summary>
    [Header("X���֣�Y����")]
    public Vector2 second;
    /// <summary>
    /// ��ʱ-��
    /// </summary>
    private int min;
    /// <summary>
    /// �Ƿ�ʼ/������ʱ
    /// </summary>                          
    private bool isCutTime=true;

    public string lossOverStr;
    public string winOverStr;
    private PlayerControllerCHANGE player;
    private void Awake()
    {
        Instance = this;
        player = FindObjectOfType<PlayerControllerCHANGE>();
    }
    private void Start()
    {
        backToMain.onClick.AddListener(GoToMain);
        restartBtn.onClick.AddListener(RestartGame);
        StartCoroutine(Timer());
    }
    /// <summary>
    /// ��Ӯ������ʾ
    /// </summary>
    /// <param name="isWin"></param>
    public void ShowGamePanel(bool isWin)
    {
        if (isWin)
        {
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = winOverStr;
            restartBtn.gameObject.SetActive(false);
        }
        else
        {
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = lossOverStr;
            restartBtn.gameObject.SetActive(true);

        }
        //ֹͣ��ʱ
        isCutTime = false;
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 1;
        gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameOverPanel.GetComponent<CanvasGroup>().interactable = true;
    }

    /// <summary>
    /// �������˵�
    /// </summary>
    public void GoToMain()
    {
        SceneManager.LoadScene("EntryPage");
    }

    /// <summary>
    /// ����
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// ��ʱЭ��
    /// </summary>
    /// <returns></returns>
    IEnumerator Timer()
    {
        while (isCutTime)
        {
            yield return new WaitForSeconds(1.0f);
            if (second.y == 0&& second.x>0)
            {
                second.x--;
                second.y = 60;
            }
            second.y--;
            if (second.y <= 0)
            {
             //  second.x--;
                if (second.x<=0&& second.y<=0)
                {
                    //��Ϸ����

                    player.isActive = false;
                     isCutTime =false;
                    ShowGamePanel(false);
                    break;
                }
              
              
            }
            timeTxt.text =second.x + "Min" + second.y + "Sec";
        }
    }
}
