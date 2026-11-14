using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    [Header("Phone Prefabs")]
    public GameObject phoneUI; // Reference to the phone prefab
    public GameObject phoneNotifUI; // Reference to the phone notification prefab

    [Header("Transforms")] //Not complete
    public Transform notifStartPos; // Starting position for the notification
    public Transform notifEndPos; // Ending position for the notification

    [Header("Phone Settings")]
    public float notifDuration = 2f; // Duration for which the notification is displayed
    public float notifMoveSpeed = 5f; // Speed at which the notification moves

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phoneNotifUI.transform.position = notifStartPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        phoneNotifUI.transform.position = Vector3.Lerp(notifStartPos.position, notifEndPos.position, notifMoveSpeed * Time.deltaTime); // Not working
    }
}
