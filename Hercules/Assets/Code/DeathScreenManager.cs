using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    private PauseMenu pauseMenu;
    private Controller controller;

    private void FixedUpdate()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= OnPlayerDeath;
    }
    public void OnPlayerDeath()
    {
        pauseMenu.PauseGame();
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        if (PlayerManager.instance != null)
        {
            Destroy(PlayerManager.instance.player);
            Destroy(PlayerManager.instance.uiCanvas);
            
        }
        SceneManager.LoadScene(2);
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
