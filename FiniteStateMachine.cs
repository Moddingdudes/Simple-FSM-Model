using System.Collections.Generic;
using UnityEngine;

namespace CyberneticStudios.FSM
{
    /// <summary>
    /// A FiniteStateMachine is a model which provides complex behaviour to any AI.
    /// </summary>
    public class FiniteStateMachine : MonoBehaviour
    {
        [Header("FiniteStateMachine Settings")]
        [SerializeField] private List<FSMTransition> _transitions = new List<FSMTransition>();
        [SerializeField] private FSMState _defaultState;

        private FSMState _activeState;

        public FSMState ActiveState => _activeState;

        private void Awake()
        {
            ChangeState(null, _defaultState);

            foreach (FSMTransition transition in _transitions)
            {
                transition.OnTransitionStateChanged += OnTransitionStateChanged;
            }
        }

        private void OnTransitionStateChanged(FSMState fromState, FSMState toState)
        {
            ChangeState(fromState, toState);
        }

        private void ChangeState(FSMState oldState, FSMState newState)
        {
            _activeState = newState;

            oldState?.DisableState();
            newState?.ActivateState();
        }
    }
}
