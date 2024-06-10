using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public AudioSource src;
    public AudioClip musique;
    // Start is called before the first frame update
    void Start()
    {
       src.clip = musique;
       src.loop = true;
       src.volume = 0.1f;
       src.Play();
    }
}
