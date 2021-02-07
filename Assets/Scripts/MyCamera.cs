using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    private AudioSource myAudioSource;
    private Camera cam;
    private float pixelsPerUnit = 300;
    private float heightInPixels, widthInPixels;

    [SerializeField] private AudioClip[] clips;
    [SerializeField] private float numObjectsWidth, numObjectsHeight;   
    
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        cam = GetComponent<Camera>();
        heightInPixels = pixelsPerUnit * numObjectsHeight;
        widthInPixels = pixelsPerUnit * numObjectsWidth;

        //SetCamera();
        StartCoroutine(playAudioSequentially());
    }

    // Update is called once per frame
    void Update()
    {
        //SetCamera();
    }

    void SetCamera()
    {
        
    }

    IEnumerator playAudioSequentially()
    {
        yield return null;

        for (int i = 0; i < clips.Length; i++)
        {
            myAudioSource.clip = clips[i];
            myAudioSource.Play();

            while (myAudioSource.isPlaying)
            {
                yield return null;
            }
        }
    }
}
