using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;

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
}
