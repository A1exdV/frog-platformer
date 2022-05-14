using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class LoadNextLevel : MonoBehaviour
{
    [SerializeField] private NextLevelEnters.nextLevelEnter enter;

    private float _playerX;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _playerX = GameObject.Find("Frog").GetComponent<Transform>().position.x;
    }

    private void OnBecameVisible()
    {
        int index;
        switch (enter)
        {
            case NextLevelEnters.nextLevelEnter.Down:
                index = Random.Range(0, LevelsData.LevelsDown.Count);
                Instantiate(LevelsData.LevelsDown[index], transform.position, transform.rotation);
                break;
            case NextLevelEnters.nextLevelEnter.Mid:
                index = Random.Range(0, LevelsData.LevelsMid.Count);
                Instantiate(LevelsData.LevelsMid[index], transform.position, transform.rotation);
                break;
            case NextLevelEnters.nextLevelEnter.Up:
                index = Random.Range(0, LevelsData.LevelsUp.Count);
                Instantiate(LevelsData.LevelsUp[index], transform.position, transform.rotation);
                break;
        }

        Destroy(this.gameObject);
    }
}