using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;

    private void OnEnable()
    {
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void ContinueButton()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
}
