using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScaleFill : MonoBehaviour
{
    private Image _image;
    [SerializeField] private float speed;

    private void OnEnable()
    {
        if (_image == null)
            _image = GetComponent<Image>();
        _image.fillAmount = 0;
    }
    void FixedUpdate()
    {
        _image.fillAmount += speed * Time.deltaTime;
    }
}
