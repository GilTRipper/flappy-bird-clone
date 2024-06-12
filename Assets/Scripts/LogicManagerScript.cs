

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicManagerScript : MonoBehaviour
{
    private int _score;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject _gameOverScreen;
    //best score field where we write value from RN part
    public TextMeshProUGUI bestScoreText;
    [SerializeField]
    private GameObject _startScreen;
    [SerializeField]
    private GameObject _game;

    [ContextMenu("Increase Score")]
    public void IncreaseScore(int number)
    {
        _score += number;
        _scoreText.text = _score.ToString();
    }

    //rewrite bestScoreText value with RN message
    public void SetBestScore(string message)
    {
        bestScoreText.text = message;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
    }

    public void StartGame()
    {
        _startScreen.SetActive(false);
        _game.SetActive(true);
    }
}
