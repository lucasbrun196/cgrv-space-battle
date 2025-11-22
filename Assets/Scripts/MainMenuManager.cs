using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject initialMenu;
    [SerializeField] private GameObject difficultyMenu;
    [SerializeField] private GameObject aboutMenu;
    [SerializeField] private GameObject rankingMenu;
    public void PlayEasy()
    {
        GameDifficulty.asteroidCount = 10;
        GameDifficulty.enemyCount = 5;
        SceneManager.LoadScene(sceneName);
    }

    public void PlayMedium()
    {
        GameDifficulty.asteroidCount = 15;
        GameDifficulty.enemyCount = 8;
        SceneManager.LoadScene(sceneName);
    }
    public void PlayHard()
    {
        GameDifficulty.asteroidCount = 20;
        GameDifficulty.enemyCount = 11;
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
