using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("UI Element")]
    public GameObject gameOverPanel; 

    [Header("Listen to event channels")]
    public VoidEventChannel onPlayerDeath;

    private void OnEnable()
    {
        onPlayerDeath.OnEventRaised += OnGameOver;
    }

    public void OnGameOver()
    {
        Debug.Log("<size=15><color=#FF0000><b>GameOver! Logiciel activé</b></color></size>");
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    private void OnDisable()
    {
        onPlayerDeath.OnEventRaised -= OnGameOver;
    }
}