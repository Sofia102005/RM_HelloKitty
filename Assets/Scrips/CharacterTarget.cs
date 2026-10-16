using UnityEngine;

public class CharacterTarget : MonoBehaviour
{
    AudioSource src;

    void Start()
    {
        src = GetComponentInChildren<AudioSource>(true);
        var handler = GetComponent<DefaultObserverEventHandler>();
        handler.OnTargetFound.AddListener(() => { if (src != null) src.Play(); });
        handler.OnTargetLost.AddListener(() => { if (src != null) src.Stop(); });
    }
}