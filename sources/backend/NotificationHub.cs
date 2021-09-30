using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalRZone
{
    namespace Hubs
    {
        /// <summary>
        /// Хаб SignalR
        /// </summary>
        public class NotificationHub : Hub
        {
            /// <summary>
            /// Метод вызывается при подключении клиента к хабу
            /// </summary>
            /// <returns></returns>
            public override Task OnConnected()
            {
                //получаем имя пользователя
                string name = Context.User.Identity.Name;
                
                //добавляем соединение в одноименную группу
                Groups.Add(Context.ConnectionId, name);

                return base.OnConnected();
            }


        }
    }
}