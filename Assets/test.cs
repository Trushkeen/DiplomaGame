using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Texture2D[] tex;
    public Rect[] Rect;
    // Start is called before the first frame update
    void Start()
    {
        Texture2D atlas = new Texture2D(8192, 8192);
        Rect = atlas.PackTextures(tex, 2, 8192);
    }
}
