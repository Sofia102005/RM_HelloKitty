using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void IrAImageTarget() => SceneManager.LoadScene("ImageTarget");
    public void IrAGroundPlane() => SceneManager.LoadScene("GroundPlane");
    public void IrAMidAir()      => SceneManager.LoadScene("MidAir");
    public void Volver()         => SceneManager.LoadScene("Menu");
}