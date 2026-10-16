using UnityEngine;

public class PinchScale : MonoBehaviour
{
    public float minFactor = 0.3f;   
    public float maxFactor = 5f;    

    Vector3 initialScale;
    float currentFactor = 1f;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (Input.touchCount != 2) return;

        Touch a = Input.GetTouch(0), b = Input.GetTouch(1);
        float prev = ((a.position - a.deltaPosition) - (b.position - b.deltaPosition)).magnitude;
        float curr = (a.position - b.position).magnitude;
        if (prev == 0) return;

        currentFactor = Mathf.Clamp(currentFactor * (curr / prev), minFactor, maxFactor);
        transform.localScale = initialScale * currentFactor;
    }
}