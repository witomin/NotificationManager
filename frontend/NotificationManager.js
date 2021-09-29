/**Массив с тостами */
let Toasts = [];
/**Инициализировать менеджер уведомлений */

function NotificationManagerInit() {
    // Ссылка на прокси хаба SignalR
    let NotificationHub = $.connection.notificationHub;

    //функция, вызываемая при получении  сообщения SignalR
    NotificationHub.client.message = function (msg) {
        ShowNotification(msg);
    };

    // Открываем соединение с хабом
    $.connection.hub.start();
}
/**
 * Показать уведомление
 * @param {any} Message
 */
function ShowNotification(Message) {

    //парсим сообщение из json
    const Notification = JSON.parse(Message);

    //если сообщение ошибка или выполнено их нужно пересоздать, чтобы они не скрывались в дальнейшем
    if (Notification.Type === 1 || Notification.Type === 3) {
        let tost = {};
        if (tost = Toasts.find((item, index, array) => item.id == Notification.ProcessId)) {
            tost.toast.close();
            Toasts = Toasts.filter((item, index, array) => item.id != Notification.ProcessId);
        }
    }
    //если существует тост для процесса с конкретным ID, модифицируем его
    if (Toasts.find((item, index, array) => item.id == Notification.ProcessId)) {
        let myToast = Toasts.find((item, index, array) => item.id == Notification.ProcessId)
        myToast.toast.update(GetTostOptions(Notification));
    }
    else {// иначе создаем
        let myToast = {};
        myToast.id = Notification.ProcessId;
        myToast.toast = $.toast(GetTostOptions(Notification));
        Toasts.push(myToast);//добавляем в масиив
    }
}
/**
 * Получить настройки для тоста
 * @param {any} notification
 */
function GetTostOptions(notification) {
    let options = {
        heading: notification.Title,
        text: notification.Message,
        icon: notification.Icon,
        hideAfter: (notification.Type === 0 || notification.Type === 2 ? 5000 : false), //скрывать только сообщения info и warning через 5 с
        stack: 10,
        //после скрытия тоста удалем его из массива, чтобы при необходимости показа он был создан заново
        afterHidden: function () {
            Toasts = Toasts.filter((item, index, array) => item.id != notification.ProcessId);
        }
    }
    return options;
}