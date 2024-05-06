using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SO_AudiosM", menuName = "ScriptableObject/SO_AudiosM/Audios")]
public class SO_AudiosM : ScriptableObject
{
    [SerializeField] public AudioSource principalAudio;
    [SerializeField] public AudioClip clip;
    private void OnEnable()
    {
        
    }
}
 