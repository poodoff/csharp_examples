using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace DateTimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = "superGift";
            var random = new Random();

            for (int i = 0; i < 5; i++)
            {
                ActionHandler<string> mainHandler;
                var cardHandler = new CardActionHandler<string>();
                var giftCardHandler = new GiftCardActionHandler<string>();

                if (random.Next(10) > 5) // Какое-то условия, например включена какая-то фича
                    mainHandler = cardHandler;
                else
                {
                    giftCardHandler.SetNextHandler(cardHandler);
                    mainHandler = giftCardHandler;
                }

                mainHandler.Click(data);
            }
        }
    }

    abstract class ActionHandler<T>
    {
        protected ActionHandler<T> _handler;

        public void SetNextHandler(ActionHandler<T> handler)
        {
            _handler = handler;
        }

        public virtual void Click(T data)
        {
            if (_handler != null)
                _handler.Click(data);
            else
                Console.WriteLine("Data is: " + data);
        }
    }

    class CardActionHandler<T> : ActionHandler<T>
    {
        public override void Click(T data)
        {
            if (data is string)
                ShowChooseDailog();
            else
                base.Click(data);
        }

        private void ShowChooseDailog()
        {
            Console.WriteLine("Card dialog");
        }
    }

    class GiftCardActionHandler<T> : ActionHandler<T>
    {
        public override void Click(T data)
        {
            if (data is string str && str == "superGift")
                ShowPresentDialog();
            else
                base.Click(data);
        }

        private void ShowPresentDialog()
        {
            Console.WriteLine("Present dialog");
        }
    }
}
