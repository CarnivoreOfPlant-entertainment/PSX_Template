using UnityEngine;

public class RotateZ : MonoBehaviour
{
    public float rotationSpeed = 1f;
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
