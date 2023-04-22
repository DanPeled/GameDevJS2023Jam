using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    public GameObject gameOverUI;

    void Start()
    {
        gameEnded = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            AudioManager.i.PlaySFX("click");
        }
        if (gameEnded) return;
        if (PlayerStats.health <= 0)
        {
            EndGame();
        }

        // prevent health from becoming negative
        PlayerStats.health = (int)Mathf.Clamp(PlayerStats.health, 0, Mathf.Infinity);
    }
    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}