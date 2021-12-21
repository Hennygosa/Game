using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VolumeValue1 : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSrc;
    private float musicVolume = 1f;

    private VolumeValue1 instance;
    
    public void SetVolume(float vol)
    {
         musicVolume = vol;
        audioSrc.volume = musicVolume;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        audioSrc = FindObjectOfType<MusicSource>().GetComponent<AudioSource>();
        audioSrc.volume = musicVolume;
    }

    private void Start()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if(this != instance)
        {
            Destroy(gameObject);
            return;
        }
        
        SceneManager.sceneLoaded += OnSceneLoaded;
        audioSrc = FindObjectOfType<MusicSource>().GetComponent<AudioSource>();
        audioSrc.volume = musicVolume;
    }
    

}
