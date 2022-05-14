using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int timeToAdd;
    [SerializeField] private GameObject flyPivot;
    [SerializeField] private Timer timer;
    private FrogController _controller;

    private GameObject _fly;

    private void Start()
    {
        _fly = null;
        _controller = GetComponentInParent<FrogController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Fly"))
        {
            _fly = col.gameObject;
            _fly.transform.parent = flyPivot.transform;
            col.GetComponentInChildren<Animator>().enabled = false;
            col.GetComponentInChildren<Transform>().localPosition = Vector3.zero;
            col.enabled = false;
        }
    }

    public void OnAttackEnd()
    {
        _controller.OnAttackEnd();
        if (_fly == null)
            return;
        timer.AddTime(timeToAdd);
        Destroy(_fly);

        _fly = null;
    }
}