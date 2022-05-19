using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.IO;
using System.Text.RegularExpressions;

namespace UkrajinskaLatynka
{
    class Program
    { 
        private static string token = "Here should be your Telegram token";
        private static ITelegramBotClient botClient;

        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            botClient = new TelegramBotClient(token);
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Console.WriteLine("The bot is currently running.");
            Console.ReadKey();
        }
        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                string ans = Translator.Reply(e.Message.Text);
                if (Regex.IsMatch(ans, "^/report.+"))
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat, "Дякую, Ваше повідомлення було записано");
                    await botClient.SendTextMessageAsync(511268325, e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + e.Message.Chat.Id + ": " + ans);
                }
                else
                {
                    await botClient.SendTextMessageAsync(e.Message.Chat, ans);
                }
            }
        }
    }
}
