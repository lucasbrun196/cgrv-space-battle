using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject initialMenu;
    [SerializeField] private GameObject difficultyMenu;
    [SerializeField] private GameObject aboutMenu;
    [SerializeField] private GameObject rankingMenu;
    [SerializeField] private GameObject totalTime;

    public TMP_Text rankingTimeValue;

    public void PlayEasy()
    {
        GameDifficulty.asteroidCount = 10;
        GameDifficulty.enemyCount = 10;
        GameDifficulty.enemiesToWin = 5;
        GameDifficulty.totalTime = 120f;
        SceneManager.LoadScene(sceneName);
    }

    public void PlayMedium()
    {
        GameDifficulty.asteroidCount = 20;
        GameDifficulty.enemyCount = 15;
        GameDifficulty.enemiesToWin = 8;
        GameDifficulty.totalTime = 90f;
        SceneManager.LoadScene(sceneName);
    }
    public void PlayHard()
    {
        GameDifficulty.asteroidCount = 30;
        GameDifficulty.enemyCount = 20;
        GameDifficulty.enemiesToWin = 12;
        GameDifficulty.totalTime = 60f;
        SceneManager.LoadScene(sceneName);
    }

    public void OpenDifficultyMenu()
    {
        difficultyMenu.SetActive(true);
        initialMenu.SetActive(false);
    }
    public void CloseDifficultyMenu()
    {
        initialMenu.SetActive(true);
        difficultyMenu.SetActive(false);
    }
    public void OpenRankingMenu()
    {
        float lastTime = PlayerPrefs.GetFloat("lastLevelTime", 0f);
        int minutes = Mathf.FloorToInt(lastTime / 60);
        int seconds = Mathf.FloorToInt(lastTime % 60);

        rankingTimeValue.text = $"{minutes:00}:{seconds:00}";
        
        rankingMenu.SetActive(true);
        initialMenu.SetActive(false);
    }
    public void CloseRankingMenu()
    {
        initialMenu.SetActive(true);
        rankingMenu.SetActive(false);
    }
    

    public void OpenAboutMenu()
    {
        aboutMenu.SetActive(true);
        initialMenu.SetActive(false);
    }

    public void CloseAboutMenu()
    {
        initialMenu.SetActive(true);
        aboutMenu.SetActive(false);
    }
}
