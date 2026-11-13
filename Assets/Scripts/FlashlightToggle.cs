using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject flashlight;

    private void OnTriggerEnter(Collider other)
    {
        flashlight.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        flashlight.SetActive(false);
    }
}
