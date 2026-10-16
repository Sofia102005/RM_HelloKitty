using UnityEngine;

public class SalirApp : MonoBehaviour
{
    public void Salir()
    {
        Debug.Log("Saliendo de la aplicación...");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}