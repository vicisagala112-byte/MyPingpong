using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Mode Game")]
    [SerializeField] private bool singlePlayer = true;   
    [Header("UI Panels")]
    [SerializeField] private GameObject playerWinPanel;
    [SerializeField] private GameObject playerLosePanel;

    [Header("Score Settings")]
    [SerializeField] private int maxScore = 5;   

    private int playerLeftScore = 0;
    private int playerRightScore = 0;

    [Header("UI Score Text")]
    [SerializeField] private Text playerLeftScoreText;
    [SerializeField] private Text playerRightScoreText;

    void Start()
    {
        playerLeftScoreText.text = "0";
        playerRightScoreText.text = "0";

        if (playerWinPanel) playerWinPanel.SetActive(false);
        if (playerLosePanel) playerLosePanel.SetActive(false);
    }

    public void PlayerLeftScored()
    {
        if (playerLeftScore >= maxScore || playerRightScore >= maxScore) return; 

        playerLeftScore++;
        playerLeftScoreText.text = playerLeftScore.ToString();
        Debug.Log("Player Left score: " + playerLeftScore);

        CheckWinCondition();
    }

    public void PlayerRightScored()
    {
        if (playerLeftScore >= maxScore || playerRightScore >= maxScore) return; 

        playerRightScore++;
        playerRightScoreText.text = playerRightScore.ToString();
        Debug.Log("Player Right score: " + playerRightScore);

        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (singlePlayer)
        {
            if (playerLeftScore >= maxScore)
            {
                if (playerWinPanel) playerWinPanel.SetActive(true);
                Debug.Log("Player Left WIN!");
                Time.timeScale = 0; 
            }
            else if (playerRightScore >= maxScore)
            {
                if (playerLosePanel) playerLosePanel.SetActive(true);
                Debug.Log("BOT WIN! Player Lose!");
                Time.timeScale = 0; 
            }
        }
        else
        {          
            if (playerLeftScore >= maxScore)
            {
                if (playerWinPanel) playerWinPanel.SetActive(true);
                Debug.Log("Player Left WIN!");
                Time.timeScale = 0;
            }
            else if (playerRightScore >= maxScore)
            {
                if (playerLosePanel) playerLosePanel.SetActive(true);
                Debug.Log("Player Right WIN!");
                Time.timeScale = 0;
            }
        }
    }

    public void pindahScene(string tujuan)
    {
        Debug.Log("Button diklik! Mau pindah ke scene: " + tujuan);

        Time.timeScale = 1;
        SceneManager.LoadScene(tujuan);
    }

}
