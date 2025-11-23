using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject victoryText;

    [SerializeField] private TMP_Text counterText;
    [SerializeField] private TMP_Text timerText;

    public int enemiesKilled = 0;
    public int enemiesToWin;

    private float currentTime;

    void Start()
    {
        currentTime = GameDifficulty.totalTime;
        enemiesToWin = GameDifficulty.enemiesToWin;
        UpdateCounterUI();
        UpdateTimerUI();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOver();
        }

        UpdateTimerUI();
    }

    public void AddKill()
    {
        enemiesKilled++;
        UpdateCounterUI();
    }

    void UpdateCounterUI()
    {
        counterText.text = enemiesKilled + "/" + enemiesToWin;
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    public void StartVictory()
    {
        StartCoroutine(VictoryRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MenuScene");
    }

    IEnumerator VictoryRoutine()
    {
        victoryText.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MenuScene");
    }
}
