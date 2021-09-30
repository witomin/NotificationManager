using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Web;

/// <summary>
/// Менеджер всплывающих уведомлений
/// </summary>
public class NotificationManager
{
    public NotificationManager()
    {
        var rand = new Random();
        var date = DateTime.Now;
        Id = date.Year + rand.Next().ToString() +
            date.Month + rand.Next().ToString() +
            date.Day + rand.Next().ToString() +
            date.Hour + rand.Next().ToString() +
            date.Minute + rand.Next().ToString() +
            date.Second + rand.Next().ToString() +
            date.Millisecond;
    }
    /// <summary>
    /// Идентификатор процесса
    /// </summary>
    private string Id { get; }

    //контекст хаба SignalR
    private IHubContext context { get { return GlobalHost.ConnectionManager.GetHubContext<SignalRZone.Hubs.NotificationHub>(); } }

    /// <summary>
    /// Отправить сообщение на все соединения текущему пользователю
    /// </summary>
    /// <param name="Notification"></param>
    public void SendNotification(Notification Notification)
    {
        Notification.ProcessId = Id;
        //сообщение отправляется на группу, одноименную пользователю, где хранятся все соединения от данного пользователя
        context.Clients.Group(HttpContext.Current.User.Identity.Name).message(JsonConvert.SerializeObject(Notification, Formatting.None));
    }

    /// <summary>
    /// Отправить сообщение пользователю на все соединения
    /// </summary>
    /// <param name="UserName"></param>
    /// <param name="Notification"></param>
    public void SendNotification(string UserName, Notification Notification)
    {
        Notification.ProcessId = Id;
        //сообщение отправляется на группу, одноименную пользователю, где хранятся все соединения от данного пользователя
        context.Clients.Group(UserName).message(JsonConvert.SerializeObject(Notification, Formatting.None));
    }
    /// <summary>
    /// Отправить информационное сообщение
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public void SendInfo(string userName, string title, string message)
    {
        var Notification = new Notification()
        {
            Title = title,
            Message = message,
            Type = NotificationTypes.info
        };
        SendNotification(userName, Notification);
    }
    /// <summary>
    /// Отправить предупреждение 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public void SendWarning(string userName, string title, string message)
    {
        var Notification = new Notification()
        {
            Title = title,
            Message = message,
            Type = NotificationTypes.warning
        };
        SendNotification(userName, Notification);
    }
    /// <summary>
    /// Отправить сообщение об ошибке
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public void SendError(string userName, string title, string message)
    {
        var Notification = new Notification()
        {
            Title = title,
            Message = message,
            Type = NotificationTypes.error
        };
        SendNotification(userName, Notification);
    }
    /// <summary>
    /// Отправить сообщение об успехе
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public void SendSuccess(string userName, string title, string message)
    {
        var Notification = new Notification()
        {
            Title = title,
            Message = message,
            Type = NotificationTypes.success
        };
        SendNotification(userName, Notification);
    }
    /// <summary>
    /// Отправить информационное сообщение
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public void SendInfo(string title, string message)
    {
        var Notification = new Notification()
        {
            Title = title,
            Message = message,
            Type = NotificationTypes.info
        };
        SendNotification(Notification);
    }
    /// <summary>
    /// Отправить предупреждение 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public void SendWarning(string title, string message)
    {
        var Notification = new Notification()
        {
            Title = title,
            Message = message,
            Type = NotificationTypes.warning
        };
        SendNotification(Notification);
    }
    /// <summary>
    /// Отправить сообщение об ошибке
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public void SendError(string title, string message)
    {
        var Notification = new Notification()
        {
            Title = title,
            Message = message,
            Type = NotificationTypes.error
        };
        SendNotification(Notification);
    }
    /// <summary>
    /// Отправить сообщение об успехе
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    public void SendSuccess(string title, string message)
    {
        var Notification = new Notification()
        {
            Title = title,
            Message = message,
            Type = NotificationTypes.success
        };
        SendNotification(Notification);
    }
}
