using UnityEngine;
using System.Collections;

public class NotificationManager : MonoBehaviour
{
    [Header("References")]
    public PhoneManager phoneManager; // Reference to the phone manager
    public float notifMoveSpeed = 5f; // Speed at which the notification moves
    public float notifDuration = 2f; // Duration for which the notification is displayed

    [Header("Text")]
    public string notifName; // Name of the notification
    public string notifText; // Text of the notification
    public string contactsPhoneText; // Text of the contacts phone
    public string sendersPhoneText; // Text of the sender's phone

    [Header("Phone Settings")]
    public float contactsTextBubbleWidth; // Width of the contacts text bubble
    public float sendersTextBubbleWidth; // Width of the sender's text bubble
    public float contactsTextBubbleHeight; // Height of the contacts text bubble
    public float sendersTextBubbleHeight; // Height of the sender's text bubble
    public float contactsTextBubblePosX; // X position of the contacts text bubble
    public float sendersTextBubblePosX; // X position of the sender's text bubble
    public float contactsTextBubblePosY; // Y position of the contacts text bubble
    public float sendersTextBubblePosY; // Y position of the sender's text bubble

    

    public void SendNotification()
    {
        phoneManager.notifNameText.text = notifName;
        phoneManager.notifText.text = notifText;

        phoneManager.ShowNotification(notifMoveSpeed, notifDuration);

        UpdatePhoneText();
    }

    public void UpdatePhoneText()
    {
        phoneManager.contactsText.text = contactsPhoneText;
        phoneManager.sendersText.text = sendersPhoneText;
        phoneManager.UpdatePhoneText(contactsPhoneText, sendersPhoneText, contactsTextBubbleWidth, sendersTextBubbleWidth, contactsTextBubbleHeight, sendersTextBubbleHeight, contactsTextBubblePosX, sendersTextBubblePosX, contactsTextBubblePosY, sendersTextBubblePosY);
    }
}
