
/// <summary>
/// Уведомление
/// </summary>
public class Notification
{
    /// <summary>
    /// Id процесса, к которому относится сообщение
    /// </summary>
    public string ProcessId { get; set; }
    /// <summary>
    /// Тип сообщения
    /// </summary>
    public NotificationTypes Type { get; set; }
    /// <summary>
    /// Заголовок сообщения
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Сообщение
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// Иконка
    /// </summary>
    public string Icon { get { return Type.ToString(); } }
}
