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

    public TMP_Text rankingTimeValue1;
    public TMP_Text rankingTimeValue2;
    public TMP_Text rankingTimeValue3;

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
        float t1 = PlayerPrefs.GetFloat("top1", 0f);
        float t2 = PlayerPrefs.GetFloat("top2", 0f);
        float t3 = PlayerPrefs.GetFloat("top3", 0f);

        rankingTimeValue1.text = t1 > 0 ? FormatTime(t1) : "--:--";
        rankingTimeValue2.text = t2 > 0 ? FormatTime(t2) : "--:--";
        rankingTimeValue3.text = t3 > 0 ? FormatTime(t3) : "--:--";

        rankingMenu.SetActive(true);
        initialMenu.SetActive(false);
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
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
