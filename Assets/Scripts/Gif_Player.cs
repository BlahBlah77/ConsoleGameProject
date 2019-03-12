using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gif_Player : MonoBehaviour {

    [SerializeField] private Texture2D[] frameArray;
    [SerializeField] private float framesPerSecond = 12.0f;

    private Material deunydd;

    private void Start()
    {
        deunydd = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        int ind = (int)(Time.time * framesPerSecond);
        ind = ind % frameArray.Length;
        deunydd.mainTexture = frameArray[ind];
    }
}
