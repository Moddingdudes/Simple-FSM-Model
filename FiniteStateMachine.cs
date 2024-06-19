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
        [SerializeField] private bool _debugTransitionStateChanges;
        [SerializeField] private bool _fsmEnabled = true;

        private FSMState _activeState;

        public FSMState ActiveState => _activeState;

        public bool FSMEnabled => _fsmEnabled;
            
        private void Start()
        {
            _activeState = _defaultState;

            foreach (FSMTransition transition in _transitions)
            {
                transition.OnTransitionStateChanged += OnTransitionStateChanged;
            }

            if (_fsmEnabled)
                ChangeState(null, _defaultState);
        }

        public void SetFSMState(FSMState state)
        {
            if (!_fsmEnabled)
            {
                Debug.LogError("Cannot change FSM state while FSM is disabled.");
                return;
            }

            ChangeState(_activeState, state);
        }

        public void EnableFSM()
        {
            _fsmEnabled = true;

            _activeState?.ActivateState();
        }

        public void DisableFSM()
        {
            _fsmEnabled = false;

            _activeState?.DisableState();
        }

        private void OnTransitionStateChanged(FSMState fromState, FSMState toState)
        {
            if (!_fsmEnabled) return;

            ChangeState(fromState, toState);

            if (_debugTransitionStateChanges)
                Debug.Log($"Transition state changed: {fromState}->{toState}");
        }

        private void ChangeState(FSMState oldState, FSMState newState)
        {
            if (!_fsmEnabled)
            {
                Debug.LogError("Cannot change state while FSM is disabled.");
                return;
            }

            _activeState = newState;

            oldState?.DisableState();
            newState?.ActivateState();
        }
    }
}
