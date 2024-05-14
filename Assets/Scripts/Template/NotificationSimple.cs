using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif
public class NotificationSimple : MonoBehaviour
{
    private const string idCanal = "canalNotificacion";

    private void Start()
    {

        RequestAuhtorization();
        RegisterNotificationChannel();

    }


    public void RequestAuhtorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    //Register a Notification Channel
    public void RegisterNotificationChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel
        {
            Id = "default_channel",
            Name = "Default",
            Importance = Importance.Default,
            Description = "Notifications"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    //Set Up Notification Template
    public void SendNotification(string title, string text, int fireTimeInHours)
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = DateTime.Now.AddHours(fireTimeInHours);
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }

    public void ButtonFunction()
    {
        SendNotification("Dummy Notification", "This is a sample Notification", 0);
    }
    public void NotiGameOver(int score)
    {
        SendNotification("NotiGameOver", "You Score is : " + score, 0);
    }
    public void NewMaxScore(int score)
    {
        SendNotification("NewMaxScore", "The MaxScore is : " + score, 0);
    }
    public void SendNotification(Notifs_SO notifs)
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = notifs.title;
        notification.Text = notifs.text;
        notification.FireTime = DateTime.Now.AddHours(notifs.fireTimeInHours);
        notification.SmallIcon = notifs.SmallIcon;
        notification.LargeIcon = notifs.LargeIcon;

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }

}