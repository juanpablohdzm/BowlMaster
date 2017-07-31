using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    //public AudioClip[] LevelMusicChangeArray;

    private AudioSource audioSource;
    private AudioClip PreviousClip;
    private AudioClip ThisLevelClip;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = LevelMusicChangeArray[0];
        audioSource.Play();
    }

    private void OnLevelWasLoaded(int level)
    {
        
        // ThisLevelClip = LevelMusicChangeArray[level];
        //if (ThisLevelClip != null && ThisLevelClip!=PreviousClip)
        //{
        //    PreviousClip = ThisLevelClip;
        //    audioSource.clip = ThisLevelClip;
        //    audioSource.loop = true;
        //    audioSource.Play();
        //}
    }

    public void ChangeVolume(float Volume)
    {
        audioSource.volume = Volume;
    }
}
