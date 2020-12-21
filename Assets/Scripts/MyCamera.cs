using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    private AudioSource myAudioSource;

    [SerializeField]
    private AudioClip[] clips;    
    
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        StartCoroutine(playAudioSequentially());
    }

    // Update is called once per frame
    void Update()
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
