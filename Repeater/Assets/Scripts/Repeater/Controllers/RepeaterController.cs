using System;
using System.Collections.Generic;
using Repeater.States;
using UnityEngine;

namespace Repeater.Controllers
{
    public class RepeaterController : MonoBehaviour
    {
        // Очередь состояний
        private Queue<IState> m_States;
    
        // Последнее состояние
        private IState m_LastState;
    
        // Обработчики состояни
        private Dictionary<Type, IRepeatActionController> m_Controllers = new Dictionary<Type, IRepeatActionController>();

        // Время запуска первого состояния
        private float m_SpawnTime;


        // Инициализация
        public void Init(Queue<IState> states)
        {
            m_States = new Queue<IState>(states);

            foreach (var controller in GetComponents<IRepeatActionController>())
            {
                m_Controllers.Add(controller.ControllerType, controller);
            }
        }

        // Выполнить состояние
        private void Execute(IState state)
        {
            GetController(state.GetType())?.Process(state);
        }

        // Получить обработчик состояния
        private IRepeatActionController GetController(Type stateType)
        {
            IRepeatActionController result;
            m_Controllers.TryGetValue(stateType, out result);
            return result;
        }
    
        private void FixedUpdate()
        {
            if (m_States.Count > 0)
            {
                if (m_LastState == null)
                {
                    m_LastState = m_States.Dequeue();
                    m_SpawnTime = Time.realtimeSinceStartup;
                }
                else if (m_LastState.Ended(m_SpawnTime))
                {
                    m_LastState = m_States.Dequeue();
                }

                Execute(m_LastState);
            }
        }
    }
}