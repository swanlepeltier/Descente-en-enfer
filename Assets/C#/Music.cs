using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{

    public AudioSource src;
    public AudioClip musique;
    public AudioClip musique_boss;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "salle du boss"){
            src.clip = musique_boss;
        }
        else{
            src.clip = musique;
        }
        src.loop = true;
        src.volume = 0.1f;
        src.Play();
    }
}
