using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioFromAnimation : MonoBehaviour
{
    AudioSource sfxSource;
    Animator animator;
    GroundDetector detector;
    AudioManager audioManager;

    private void Awake()
    {
        sfxSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        detector = FindObjectOfType<GroundDetector>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PlaySound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    private void LateUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Rogue_idle_01") ||
            !animator.enabled)
            sfxSource.Stop();

        if (transform.position.y < detector.fallThreshold + 1)
            audioManager.PlaySound(audioManager.dieSound);
    }
}
