using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject aboutGame;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject CreditsPanel;

    [SerializeField] private GameObject slide1;
    [SerializeField] private GameObject slide2;

    [SerializeField] private TextMeshProUGUI prevButton;
    [SerializeField] private TextMeshProUGUI nextButton;

    public void  PlayButton()
    {
        mainMenu.SetActive(false);
        aboutGame.SetActive(true);
    }

    public void NextButton()
    {
        if (slide1.activeInHierarchy)
        {
            slide1.SetActive(false);
            slide2.SetActive(true);
            prevButton.text = "Prev";
            nextButton.text = "Play";
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void PrevButton()
    {
        if (slide2.activeInHierarchy)
        {
            slide2.SetActive(false);
            slide1.SetActive(true);
            prevButton.text = "Return";
            nextButton.text = "Next";
        }
        else
        {
            aboutGame.SetActive(false);
            mainMenu.SetActive(true);

        }
    }

    public void CreditsState()
    {
        CreditsPanel.SetActive(!CreditsPanel.activeInHierarchy);
    }
}
