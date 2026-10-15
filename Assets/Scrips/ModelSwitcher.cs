using UnityEngine;

public class ModelSwitcher : MonoBehaviour
{
    public GameObject[] models;
    public AudioClip[] sounds;
    int index = 0;
    AudioSource src;

    void Start()
    {
        src = gameObject.AddComponent<AudioSource>();
        // Activa el primer modelo sin reproducir audio al iniciar la escena
        SetModelActive(0);
    }

    public void Next() => ChangeModel((index + 1) % models.Length);
    public void Previous() => ChangeModel((index - 1 + models.Length) % models.Length);

    void ChangeModel(int i)
    {
        SetModelActive(i);
        if (sounds != null && i < sounds.Length && sounds[i] != null)
        {
            src.PlayOneShot(sounds[i]);
        }
    }

    void SetModelActive(int i)
    {
        index = i;
        for (int k = 0; k < models.Length; k++)
        {
            if (models[k] != null)
                models[k].SetActive(k == i);
        }
    }
}