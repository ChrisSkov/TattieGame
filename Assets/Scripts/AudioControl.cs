using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] float audioVolume;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        float originalVolume = audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !audioSource.isPlaying)
        {
            audioSource.volume = audioVolume;
            audioSource.PlayOneShot(clip);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            audioSource.Stop();

        }
    }
}
