using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   private AudioSource AudioPlayer;


    private void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();

    }
    public void PlaySound(AudioClip clip, float times)
    {
        StartCoroutine(ActiveBurronMen(clip, times));
    }

    IEnumerator ActiveBurronMen(AudioClip clip, float times)
    {
        yield return new WaitForSeconds(times);
        AudioPlayer.PlayOneShot(clip);
    }

}
