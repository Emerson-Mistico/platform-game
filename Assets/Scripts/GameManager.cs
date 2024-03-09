using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    #region Game Setup
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    // public List<GameObject> enemies;

    [Header("References")]
    public GameObject hudInformation;
    public GameObject hudGameOverMessage;
    public GameObject menuPauseGame;
    public GameObject menuPauseSettings;

    private GameObject _currentPlayer;
    private string _currentGameState;
    #endregion

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        _currentGameState = PlayerPrefs.GetString("GameState");

        VerifyPlayerIsAlive();

        if (Input.GetKeyDown(KeyCode.Escape) && _currentGameState == "Playing")
        {
            ShowPauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && _currentGameState == "PauseGame")
        {
            HidePauseMenu();
        }

    }

    public void Init()
    {
        hudInformation.SetActive(true);
        hudGameOverMessage.SetActive(false);
        ConfigurePlayer();
    }

    public void ShowPauseMenu()
    {
        menuPauseGame.SetActive(false);
        menuPauseSettings.SetActive(true);
        ChangeGameState("PauseGame");
        PlayerPrefs.SetInt("PlayerCanMove", 0);
        Time.timeScale = 0f;
    }

    public void HidePauseMenu()
    {
        menuPauseGame.SetActive(true);
        menuPauseSettings.SetActive(false);
        ChangeGameState("Playing");
        PlayerPrefs.SetInt("PlayerCanMove", 1);
        Time.timeScale = 1f;
    }

    public void ChangeGameState(string state)
    {
        PlayerPrefs.SetString("GameState", state);
    }

    #region Player Initial Configuration
    private void ConfigurePlayer()
    {
        PlayerPrefs.SetInt("PlayerIsAlive", 1);
        PlayerPrefs.SetInt("PlayerCanMove", 1);
        PlayerPrefs.SetInt("PlayerCanShoot", 1);
        ChangeGameState("Playing");
    }
    #endregion

    public void VerifyPlayerIsAlive()
    {
        if (PlayerPrefs.GetInt("PlayerIsAlive") == 0 ) {

            PlayerPrefs.SetInt("PlayerCanShoot", 0);
            hudInformation.SetActive(false);
            hudGameOverMessage.SetActive(true);
        }
    }

}
