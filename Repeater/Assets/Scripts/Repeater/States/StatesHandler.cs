using System.Collections.Generic;
using Repeater.Controllers;
using UnityEngine;

namespace Repeater.States
{
    public class StatesHandler : MonoBehaviour
    {
        public static StatesHandler Instance;

        private IState m_LastState;

        public RepeaterController repPrefab;

        public Transform spawnPoint;

        public Transform Player;

        Queue<IState> states = new Queue<IState>();

        private float spawnTime = 0;

        private void Awake()
        {
            Instance = this;
        }


        public void AddState(IState state)
        {
            m_LastState = state;
            m_LastState.Time = Time.realtimeSinceStartup - spawnTime;
            states.Enqueue(state);
        }

        public void AddStateUnique(IState state)
        {
            if (m_LastState != null && m_LastState.Equals(state)) return;
            AddState(state);
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                AddEndState();
                spawnTime = Time.realtimeSinceStartup;
                var position = spawnPoint.position;
                Player.position = position;
                var c = Instantiate(repPrefab, position,spawnPoint.rotation);
                c.Init(states);
                states.Clear();
            }
        }

        public void AddEndState()
        {
            AddState(new EndState(true));
        }
    }
}