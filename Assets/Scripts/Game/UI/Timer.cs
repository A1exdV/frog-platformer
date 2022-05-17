using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int time;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PopUpText popUpText;
    [SerializeField] private GameObject jumpForce;
    [SerializeField] private GameObject timePopUp;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource ambient;

    private int _score;
    private float _second;

    void Start()
    {
        TextUpdate();
        _second = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Time0Check();
        SecondsTimer();
        WarningTime();
    }

    private void Time0Check()
    {
        if (time <= 0)
        {
            deadPanel.SetActive(true);
            jumpForce.SetActive(false);
            scoreText.text = _score.ToString();
            Time.timeScale = 0;
            music.mute = true;
            ambient.mute = true;
        }
    }

    private void SecondsTimer()
    {
        _second += Time.deltaTime;
        if (!(_second >= 1f)) return;
        _second = 0;
        time--;
        _score++;
        TextUpdate();
    }

    private void WarningTime()
    {
        switch (time)
        {
            case <= 10 when !timePopUp.activeInHierarchy:
                timePopUp.SetActive(true);
                break;
            case > 10 when timePopUp.activeInHierarchy:
                timePopUp.SetActive(false);
                break;
        }
    }

    public void AddTime(int seconds)
    {
        time += seconds;
        TextUpdate();
        popUpText.gameObject.SetActive(true);
        popUpText.GetInfo(Color.yellow, "+" + seconds.ToString());
    }

    public void TakeTime(int seconds)
    {
        time -= seconds;
        if (time < 0)
            time = 0;
        TextUpdate();
        popUpText.gameObject.SetActive(true);
        popUpText.GetInfo(Color.red, "-" + seconds.ToString());
    }

    private void TextUpdate()
    {
        timerText.text = time.ToString();
    }
}