using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance { get; private set; }
    [SerializeField] private AudioSource soundFXPlayer;

    #region Singleton
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void PlaySoundFX(AudioClip clip)
    {
        if (soundFXPlayer.isPlaying) return;
        soundFXPlayer.clip = clip;
        soundFXPlayer.Play();
    }
    
}