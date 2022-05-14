using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    [SerializeField] private float speed;
    private TextMeshProUGUI _text;

    private void OnEnable()
    {
        transform.localPosition = new Vector3(225, 0, 0);
        _text = GetComponent<TextMeshProUGUI>();
        _text.alpha = 1;
    }

    public void GetInfo(Color color,string number)
    {
        transform.localPosition = new Vector3(225, 0, 0);
        _text.color = color;
        _text.text = number + " s";
    }
    void Update()
    {
        if (transform.localPosition.y > 75)
            this.enabled = false;
        _text.alpha -= speed * Time.deltaTime;
        transform.localPosition += new Vector3(0, speed * Time.deltaTime*10, 0);
    }
}
