using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject victoryText;

    [SerializeField] private TMP_Text counterText;


    public int enemiesKilled = 0;
    public int enemiesToWin = 5;

    void Start()
    {
        UpdateCounterUI();
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

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
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
