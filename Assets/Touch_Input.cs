using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

//[RequireComponent (typeof(AudioSource))]

public class Touch_Input : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer movie;
    //private new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        movie.Prepare();
        rawImage.texture = movie.texture;
        //audio = GetComponent<AudioSource>();
        //audio.clip = movie.audioClip();
        movie.Pause();
        //audio.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(0) ||Input.touchCount > 0 && !movie.isPlaying)
        {
            movie.Play();
            //audio.Play();
        }

        else if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && movie.isPlaying)
        {
            movie.Pause();
            //audio.Pause();
        }
    }
}
