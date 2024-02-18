using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Unicorn
{
    public class ActionSequence
    {
        private Queue<UnityAction> listAction;
        public ActionSequence(){
            listAction = new Queue<UnityAction>();
        }
        public void RegisterAction(UnityAction action){
            listAction.Enqueue(action);
        }
        public void ExecuteNextAction(){
            var action = listAction.Dequeue();
            action?.Invoke();
        }
    }
}
