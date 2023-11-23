using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPannel;
    [SerializeField] private GameObject _startPunnel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Player _player;

    private void Start()
    {
        Time.timeScale = 0;
        _gameOverPannel.SetActive(false);
    }

    private void OnEnable()
    {
        _startPunnel.SetActive(true);

        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    public void OpenPunnel(GameObject punnel)
    {
        punnel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePunel(GameObject punnel)
    {
        punnel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OnDied()
    {
        _gameOverPannel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnRestartButtonClic()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
