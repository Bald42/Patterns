using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class CommandController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                InvokComman();
            }
        }

        private void InvokComman()
        {
            // Клиентский код может параметризовать отправителя любыми
            // командами.
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));
            invoker.DoSomethingImportant();
        }
    }
}