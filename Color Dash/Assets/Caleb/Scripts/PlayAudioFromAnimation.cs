using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioFromAnimation : MonoBehaviour
{
    AudioSource sfxSource;
    Animator animator;

    private void Awake()
    {
        sfxSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
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
    }
}
