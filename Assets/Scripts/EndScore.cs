using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScore : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button menuButton;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        retryButton.onClick.AddListener(HandleRetryClicked);
        menuButton.onClick.AddListener(HandleMenuClicked);
        scoreText.text = "Score: " + GameManager.instance.GetScore().ToString();
        highScoreText.text = "HighScore: " + GameManager.instance.GetHighScore().ToString();
    }

    private void HandleRetryClicked()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    private void HandleMenuClicked()
    {
        GameManager.instance.StartGame();
    }
}
