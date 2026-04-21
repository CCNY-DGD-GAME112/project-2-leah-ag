using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    [Tooltip("Populate with sequence of images")]
    public List<Texture2D> myTextures = new List<Texture2D>();
    [Tooltip("Speed of sequence of images")]
    public float speed = .1f;
    [Tooltip("Start sequence at frame")]
    public int startingFrame;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = startingFrame;
        InvokeRepeating("ImageCycler", 0, speed);
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void ImageCycler()
    {
        if (counter < myTextures.Count - 1)
            counter++;
        else counter = 0;
        this.gameObject.transform.GetComponent<Renderer>().material.SetTexture("_MainTex", myTextures[counter]);
    }
}
