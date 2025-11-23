using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private GameManager manager;

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
                Debug.Log("Ainda não matou o suficiente!");
            }
        }
    }
}
