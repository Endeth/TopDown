using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour
{
    public Sprite[] otherSprites;

    private bool RandomBool()
    {
        return Random.Range(0, 2) == 1;
    }
    void Start()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = otherSprites[ Random.Range(0, otherSprites.Length ) ];
        renderer.flipX = RandomBool();
        renderer.flipY = RandomBool();
    }

    void Update()
    {
        
    }
}
