using UnityEngine;

public class RotatingTombstone : MonoBehaviour
{
    public float rotationSpeed = 15.0f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}