using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour
{
    private GameManager manager;
    public GameObject keepPlayingText;

    void Start()
    {
        manager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (manager.enemiesKilled >= manager.enemiesToWin)
            {
                manager.StartVictory();
            }
            else
            {
                StartCoroutine(KeepPlayingRoutine());
            }
        }
    }

    IEnumerator KeepPlayingRoutine()
    {
        keepPlayingText.SetActive(true);
        yield return new WaitForSeconds(2f);
        keepPlayingText.SetActive(false);
    }
}
