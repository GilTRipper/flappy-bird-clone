using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    private int _score;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject _gameOverScreen;

    [ContextMenu("Increase Score")]
    public void IncreaseScore(int number)
    {
        _score += number;
        _scoreText.text = _score.ToString();
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
        SceneManager.LoadScene("GameScene");
    }
}
