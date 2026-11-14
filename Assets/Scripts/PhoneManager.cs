using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    [Header("Phone Prefabs")]
    public GameObject phoneUI; // Reference to the phone prefab
    public GameObject phoneNotifUI; // Reference to the phone notification prefab

    [Header("Transforms")] //Not complete
    public Transform notifStartPos; // Starting position for the notification
    public Transform notifEndPos; // Ending position for the notification
    public Transform phoneStartPos; // Starting position for the phone
    public Transform phoneEndPos; // Ending position for the phone

    [Header("Phone Settings")]
    public float notifDuration = 2f; // Duration for which the notification is displayed
    public float notifMoveSpeed = 5f; // Speed at which the notification moves
    public float phoneMoveSpeed = 5f; // Speed at which the phone moves

    private bool phoneActive = false; // Flag to track if the phone is active

    [Header("Text UI")]
    public TextMeshProUGUI notifNameText; // Reference to the notification name text UI
    public TextMeshProUGUI notifText; // Reference to the notification text UI
    public TextMeshProUGUI contactsText; // Reference to the contacts text UI
    public TextMeshProUGUI sendersText; // Reference to the sender's text UI

    [Header("Image UI")]
    public Image contactsTextBubbleImage; // Reference to the contacts text bubble image UI
    public Image sendersTextBubbleImage; // Reference to the sender's text bubble image UI

    private Vector3 notifVelocity = Vector3.zero; // Velocity for smooth dampening of the notification movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phoneNotifUI.transform.position = notifStartPos.position;
        phoneUI.transform.position = phoneEndPos.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !phoneActive)
        {
            phoneUI.transform.position = Vector3.Lerp(phoneEndPos.position, phoneStartPos.position, phoneMoveSpeed * Time.time);
            phoneActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && phoneActive)
        {
            phoneUI.transform.position = Vector3.Lerp(phoneStartPos.position, phoneEndPos.position, phoneMoveSpeed * Time.time);
            phoneActive = false;
        }
    }

    public void ShowNotification(float speed, float duration)
    {
        notifMoveSpeed = speed;
        notifDuration = duration;
        //honeNotifUI.transform.position = Vector3.SmoothDamp(phoneNotifUI.transform.position, notifEndPos.position, ref notifVelocity, notifMoveSpeed);
        StartCoroutine(NotificationDuration());
    }

    public IEnumerator NotificationDuration()
    {
        //Moving Notfi not working properly, need to fix it
        phoneNotifUI.transform.position = Vector3.Slerp(notifStartPos.position, notifEndPos.position, notifMoveSpeed * Time.time);
        
        yield return new WaitForSeconds(notifDuration);
        phoneNotifUI.transform.position = Vector3.Slerp(notifEndPos.position, notifStartPos.position, notifMoveSpeed * Time.time);
    }

    public void UpdatePhoneText(string contactsText, string sendersText, float contactsTextBubbleWidth, float sendersTextBubbleWidth, float contactsTextBubbleHeight, float sendersTextBubbleHeight, float contactsTextBubblePosX, float sendersTextBubblePosX, float contactsTextBubblePosY, float sendersTextBubblePosY)
    {
        contactsTextBubbleImage.rectTransform.sizeDelta = new Vector2(contactsTextBubbleWidth, contactsTextBubbleHeight);
        sendersTextBubbleImage.rectTransform.sizeDelta = new Vector2(sendersTextBubbleWidth, sendersTextBubbleHeight);
        contactsTextBubbleImage.rectTransform.anchoredPosition = new Vector2(contactsTextBubblePosX, contactsTextBubblePosY);
        sendersTextBubbleImage.rectTransform.anchoredPosition = new Vector2(sendersTextBubblePosX, sendersTextBubblePosY);
    }
}
