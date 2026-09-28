using UnityEngine;

// Colocar en la Main Camera de cada escena de personaje.
// Asignar "target" = el modelo 3D del personaje (el Transform de su raíz).
public class SimpleOrbitCamera : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform target;

    [Header("Distancia")]
    public float distance = 4f;
    public float minDistance = 2f;
    public float maxDistance = 8f;

    [Header("Velocidad")]
    public float rotationSpeed = 150f;
    public float zoomSpeed = 4f;

    [Header("Límite vertical")]
    public float minVerticalAngle = -10f;
    public float maxVerticalAngle = 60f;

    private float currentX;
    private float currentY = 20f;

    void LateUpdate()
    {
        if (target == null) return;

        if (Input.GetMouseButton(0))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            currentY = Mathf.Clamp(currentY, minVerticalAngle, maxVerticalAngle);
        }

        distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distance);

        transform.rotation = rotation;
        transform.position = position;
    }
}
