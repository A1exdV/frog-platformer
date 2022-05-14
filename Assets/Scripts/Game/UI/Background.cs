using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private List<Transform> Layer1;
    [SerializeField] private List<Transform> Layer2;

    [SerializeField] private float layer1Speed;
    [SerializeField] private float layer2Speed;

    [SerializeField] private float spritesInterval;

    private float _prevX;
    void Start()
    {
        _prevX = player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = player.position.x;
        var delta = _prevX - playerPos;
        _prevX = playerPos;

        foreach (var sprite in Layer1)
        {
            sprite.localPosition += new Vector3(delta*layer1Speed, 0, 0);
            if (sprite.localPosition.x > spritesInterval)
            {
                sprite.localPosition += new Vector3(-spritesInterval*2, 0, 0);
            }
            if (sprite.localPosition.x < -spritesInterval)
            {
                sprite.localPosition += new Vector3(spritesInterval*2, 0, 0);
            }
        }
        foreach (var sprite in Layer2)
        {
            sprite.localPosition += new Vector3(delta*layer2Speed, 0, 0);
            if (sprite.localPosition.x > spritesInterval)
            {
                sprite.localPosition += new Vector3(-spritesInterval*2, 0, 0);
            }
            if (sprite.localPosition.x < -spritesInterval)
            {
                sprite.localPosition += new Vector3(spritesInterval*2, 0, 0);
            }
        }

    }
}
