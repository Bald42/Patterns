using UnityEngine;

namespace DesignPatterns.Command
{
    // Интерфейс Команды объявляет метод для выполнения команд.
    public interface ICommand
    {
        void Execute();
    }

    // Некоторые команды способны выполнять простые операции самостоятельно.
    class SimpleCommand : ICommand
    {
        private string payload = string.Empty;

        public SimpleCommand(string payload)
        {
            this.payload = payload;
        }

        public void Execute()
        {
            Debug.LogError($"Простая команда: видите, я могу делать простые вещи, например, печатать ({this.payload})");
        }
    }

    // Но есть и команды, которые делегируют более сложные операции другим
    // объектам, называемым «получателями».
    class ComplexCommand : ICommand
    {
        private Receiver receiver;

        // Данные о контексте, необходимые для запуска методов получателя.
        private string aString;

        private string bString;

        // Сложные команды могут принимать один или несколько объектов-
        // получателей вместе с любыми данными о контексте через конструктор.
        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this.receiver = receiver;
            this.aString = a;
            this.bString = b;
        }

        // Команды могут делегировать выполнение любым методам получателя.
        public void Execute()
        {
            Debug.LogError("Сложная команда: объект-приемник должен выполнять сложные операции.");
            this.receiver.DoSomething(this.aString);
            this.receiver.DoSomethingElse(this.bString);
        }
    }

    // Классы Получателей содержат некую важную бизнес-логику. Они умеют
    // выполнять все виды операций, связанных с выполнением запроса. Фактически,
    // любой класс может выступать Получателем.
    class Receiver
    {
        public void DoSomething(string a)
        {
            Debug.LogError($"Приемник: работает на ({a}.)");
        }

        public void DoSomethingElse(string b)
        {
            Debug.LogError($"Приемник: Также работает над ({b}.)");
        }
    }

    // Отправитель связан с одной или несколькими командами. Он отправляет
    // запрос команде.
    class Invoker
    {
        private ICommand onStart;
        private ICommand onFinish;

        // Инициализация команд
        public void SetOnStart(ICommand command)
        {
            this.onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            this.onFinish = command;
        }

        // Отправитель не зависит от классов конкретных команд и получателей.
        // Отправитель передаёт запрос получателю косвенно, выполняя команду.
        public void DoSomethingImportant()
        {
            Debug.LogError("Отправитель: Кто-нибудь хочет, чтобы что-то было сделано до того, как я начну?");
            if (this.onStart is ICommand)
            {
                this.onStart.Execute();
            }

            Debug.LogError("Отправитель: ... делать что-то действительно важное ...");

            Debug.LogError("Отправитель: Кто-нибудь хочет, чтобы что-то было сделано после того, как я закончу?");
            if (this.onFinish is ICommand)
            {
                this.onFinish.Execute();
            }
        }
    }
}