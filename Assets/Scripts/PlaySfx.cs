using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySfx : MonoBehaviour
{
    public static PlaySfx instance;

    [SerializeField]
    public AudioSource[] song;
    
    private void Awake()
    {
        instance = this;
    }

    public void PlaySfxEffect(int index)
    {
        song[index].Stop();
        song[index].Play();
    }
}
