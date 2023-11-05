using System.Collections.Generic;
using UnityEngine;

namespace CyberneticStudios.FSM
{
    /// <summary>
    /// an FSMState is a representation of what an FSM model will do when activated.
    /// </summary>
    public class FSMState : MonoBehaviour
    {
        [Header("FSMState Settings")]
        [SerializeField] private List<FSMAction> _actions = new List<FSMAction>();

        private bool _stateActive = false;

        public bool Active => _stateActive;

        public void ActivateState()
        {
            _stateActive = true;

            ActivateActions();
        }

        public void DisableState()
        {
            _stateActive = false;

            DisableActions();
        }

        private void ActivateActions()
        {
            foreach (FSMAction action in _actions)
            {
                action.ActivateAction();
            }
        }

        private void DisableActions()
        {
            foreach (FSMAction action in _actions)
            {
                action.DisableAction();
            }
        }
    }
}
