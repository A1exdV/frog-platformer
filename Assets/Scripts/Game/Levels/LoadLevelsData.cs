using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelsData : MonoBehaviour
{
    [SerializeField] private List<string> paths;


    private void Awake()
    {
        foreach (var path in paths)
        {
            var dir = new System.IO.DirectoryInfo("Assets/Resources/"+path);
            var count = dir.GetFiles().Length/2;
            var levels = new List<GameObject>();
            for (var index = 0; index < count; index++)
            {
                var obj = Resources.Load<GameObject>(path + "/Level" + index);
                levels.Add(obj);
            }

            if (LevelsData.LevelsDown == null)
            {
                LevelsData.LevelsDown = levels;
                print(LevelsData.LevelsDown.Count);
            }
            else if (LevelsData.LevelsMid == null)
            {
                LevelsData.LevelsMid = levels;
                print(LevelsData.LevelsMid.Count);
            }
            else if (LevelsData.LevelsUp == null)
            {
                LevelsData.LevelsUp = levels;
                print(LevelsData.LevelsUp.Count);
            }

        }
        Destroy(this.gameObject);
    }
}