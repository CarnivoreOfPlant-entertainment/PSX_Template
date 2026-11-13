using UnityEngine;

public class MouseKey : MonoBehaviour
{
    public bool unlockMouse = false;
    public bool lockMouse = true;

    void Update()
    {
        if (unlockMouse)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (lockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
