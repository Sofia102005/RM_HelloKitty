using UnityEngine;

public class CharacterTarget : MonoBehaviour
{
    public AudioClip sound;
    AudioSource src;

    void Start()
    {
        src = gameObject.AddComponent<AudioSource>();
        var handler = GetComponent<DefaultObserverEventHandler>();
        handler.OnTargetFound.AddListener(() => src.PlayOneShot(sound));
    }
}