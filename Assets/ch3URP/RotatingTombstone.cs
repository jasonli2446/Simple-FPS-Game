using UnityEngine;

public class RotatingTombstone : MonoBehaviour
{
    public float rotationSpeed = 10.0f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}