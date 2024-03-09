using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour
{
    // reference to check is grounded
    public Player player;
    
    public List<AudioClip> audioClipList;

    public List<AudioSource> audioSourceList;

    private int _index = 0;
    public void PlayRandom()
    {
        if (_index >= audioSourceList.Count) _index = 0;

        var audioSource = audioSourceList[_index];

        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];

        // Check reference if is grounded
        if (player != null && player.CheckIsGrounded())
        {
            audioSource.Play();
        }       

        _index++;
    }
}
