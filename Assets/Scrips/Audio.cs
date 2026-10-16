using UnityEngine;
using Vuforia;

public class audio : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clipPlanoDetectado;
    public AudioClip clipObjetoColocado;

    private bool planoAnunciado = false;

    public void OnPlanoDetectado(HitTestResult result)
    {
        if (planoAnunciado) return;
        planoAnunciado = true;
        audioSource.PlayOneShot(clipPlanoDetectado);
    }

    public void OnObjetoColocado(HitTestResult result)
    {
        audioSource.PlayOneShot(clipObjetoColocado);
    }
}