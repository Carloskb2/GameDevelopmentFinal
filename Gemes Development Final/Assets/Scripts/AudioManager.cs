using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music Tracks")]
    public AudioClip[] musicTracks;
    public int musicTrackIndex; // Public index to select from the editor

    [Header("Player Sounds")]
    public AudioClip stepSound;
    public AudioClip jumpSound;
    public AudioClip fallSound;
    public AudioClip climbUpSound;
    public AudioClip climbDownSound;
    public AudioClip getHitSound;
    public AudioClip dieSound;
    public AudioClip winSound;

    [Header("Enemy Sounds")]
    public AudioClip enemyMoveSound;
    public AudioClip enemyIdleSound;
    public AudioClip enemyAttackSound;

    [Header("Ambience Sounds")]
    public AudioClip ambience1;
    public AudioClip ambience2;
    public AudioClip ambience3;
    public AudioMixerGroup ambienceMixerGroup;

    private AudioSource musicSource;
    private AudioSource sfxSource;
    private AudioSource[] ambienceSources;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize music and SFX audio sources
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        // Initialize ambience audio sources
        ambienceSources = new AudioSource[3];
        for (int i = 0; i < ambienceSources.Length; i++)
        {
            ambienceSources[i] = gameObject.AddComponent<AudioSource>();
            ambienceSources[i].outputAudioMixerGroup = ambienceMixerGroup;
            ambienceSources[i].loop = true;
        }
    }

    void Start()
    {
        PlayMusic(musicTrackIndex);
        PlayAmbience(0, ambience1);
        PlayAmbience(1, ambience2);
        PlayAmbience(2, ambience3);
    }

    public void PlayMusic(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Length)
        {
            musicSource.clip = musicTracks[trackIndex];
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayAmbience(int index, AudioClip clip)
    {
        if (index >= 0 && index < ambienceSources.Length)
        {
            ambienceSources[index].clip = clip;
            ambienceSources[index].Play();
        }
    }

    // Additional methods for specific sounds can be added as needed
}
