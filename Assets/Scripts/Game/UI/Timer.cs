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
        if (time <= 0)
        {
            deadPanel.SetActive(true);
            scoreText.text = _score.ToString();
            Time.timeScale = 0;
        }

        _second += Time.deltaTime;
        if (!(_second >= 1f)) return;
        _second = 0;
        time--;
        _score++;
        TextUpdate();
    }

    public void AddTime(int seconds)
    {
        time += seconds;
        TextUpdate();
        popUpText.gameObject.SetActive(true);
        popUpText.GetInfo( Color.yellow, "+" + seconds.ToString());
    }

    public void TakeTime(int seconds)
    {
        time -= seconds;
        TextUpdate();
        popUpText.gameObject.SetActive(true);
        popUpText.GetInfo( Color.red, "-" + seconds.ToString());
    }

    private void TextUpdate()
    {
        timerText.text = time.ToString();
    }
}