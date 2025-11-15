using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject initialMenu;
    [SerializeField] private GameObject difficultyMenu;
    public void Play()
    {
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

}
