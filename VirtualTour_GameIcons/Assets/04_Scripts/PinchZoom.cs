using UnityEngine;

/// <summary>
/// Zoom con dos dedos en el celular. Poner en la Main Camera, junto a SimpleOrbitCamera.
/// </summary>
[RequireComponent(typeof(SimpleOrbitCamera))]
public class PinchZoom : MonoBehaviour
{
    public float speed = 0.01f;
    private SimpleOrbitCamera orbit;

    private void Awake() { orbit = GetComponent<SimpleOrbitCamera>(); }

    private void Update()
    {
        if (Input.touchCount != 2) return;
        Touch a = Input.GetTouch(0), b = Input.GetTouch(1);
        float prev = ((a.position - a.deltaPosition) - (b.position - b.deltaPosition)).magnitude;
        float cur = (a.position - b.position).magnitude;
        orbit.distance = Mathf.Clamp(orbit.distance - (cur - prev) * speed, orbit.minDistance, orbit.maxDistance);
    }
}
