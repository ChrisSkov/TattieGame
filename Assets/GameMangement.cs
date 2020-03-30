using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangement : MonoBehaviour
{
    AudioSource source;
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (source.isPlaying == false)
        {
            source.PlayOneShot(clip);
        }
    }
}
