using UnityEngine;

public class ModelSwitcher : MonoBehaviour
{
    public GameObject[] models;   // los 10 personajes, cada uno con su AudioSource
    int index = 0;
    bool targetVisible = false;

    void Start()
    {
        Show(0, false);

        var handler = GetComponent<DefaultObserverEventHandler>();
        if (handler != null)
        {
            handler.OnTargetFound.AddListener(() =>
            {
                targetVisible = true;
                PlayCurrent();
            });
            handler.OnTargetLost.AddListener(() =>
            {
                targetVisible = false;
                StopAll();
            });
        }
    }

    public void Next()     => Show((index + 1) % models.Length, true);
    public void Previous() => Show((index - 1 + models.Length) % models.Length, true);

    void Show(int i, bool playSound)
    {
        StopAll();
        index = i;
        for (int k = 0; k < models.Length; k++)
            models[k].SetActive(k == i);

        if (playSound) PlayCurrent();
    }

    void PlayCurrent()
    {
        var audio = models[index].GetComponent<AudioSource>();
        if (audio != null && audio.clip != null) audio.Play();
    }

    void StopAll()
    {
        foreach (var m in models)
        {
            var a = m.GetComponent<AudioSource>();
            if (a != null) a.Stop();
        }
    }
}