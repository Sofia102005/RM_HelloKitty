using UnityEngine;
using UnityEngine.EventSystems;
using Vuforia;

public class GroundPlaneAudio : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clipPlanoDetectado;
    public AudioClip clipObjetoColocado;

    [Header("Volumen (1 = normal, más de 1 = más fuerte)")]
    [Range(0f, 3f)] public float volumenPlano = 2f;
    [Range(0f, 3f)] public float volumenColocado = 2.5f;

    private bool planoAnunciado = false;
    private float ultimoHit = -10f;
    private float ultimoColocado = -10f;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.volume = 1f;
            audioSource.spatialBlend = 0f; // sonido 2D, sin atenuación por distancia
            audioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        // Respaldo: toque en pantalla (fuera de botones) con plano detectado
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began &&
                !EventSystem.current.IsPointerOverGameObject(t.fingerId) &&
                Time.time - ultimoHit < 0.5f)
            {
                ReproducirColocado();
            }
        }
    }

    public void OnPlanoDetectado(HitTestResult result)
    {
        if (Time.time - ultimoHit > 2f)
            planoAnunciado = false;

        ultimoHit = Time.time;

        if (planoAnunciado) return;
        planoAnunciado = true;
        audioSource.PlayOneShot(clipPlanoDetectado, volumenPlano);
    }

    public void OnObjetoColocado(HitTestResult result)
    {
        ReproducirColocado();
    }

    void ReproducirColocado()
    {
        // Evita que suene doble (evento + toque)
        if (Time.time - ultimoColocado < 0.5f) return;
        ultimoColocado = Time.time;
        audioSource.PlayOneShot(clipObjetoColocado, volumenColocado);
    }
}