using System;
using Repeater.States;
using UnityEngine;

namespace Repeater.Controllers
{
    [RequireComponent(typeof(StatesHandler))]
    public abstract class RepeatActionControllerBase<T> : MonoBehaviour, IRepeatActionController where T : IState
    {
        public Type ControllerType => typeof(T);

        public void Process(object actionParameter)
        {
            Process((T) actionParameter);
        }

        protected abstract void Process(T actionParameter);
    }
}