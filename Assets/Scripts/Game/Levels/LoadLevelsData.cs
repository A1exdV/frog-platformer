using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelsData : MonoBehaviour
{
    [SerializeField] private List<string> paths;
    [SerializeField] private List<GameObject> up;
    [SerializeField] private List<GameObject> mid;
    [SerializeField] private List<GameObject> down;

    private void Awake()
    {
        LevelsData.LevelsDown = down;
        LevelsData.LevelsMid = mid;
        LevelsData.LevelsUp = up;
        Destroy(this.gameObject);
    }
}