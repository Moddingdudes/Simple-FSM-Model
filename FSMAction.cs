using UnityEngine;

namespace CyberneticStudios.FSM
{
    /// <summary>
    /// An FSMAction is what an FSM is going to do when the parent state is enabled.
    /// For example: An action may be to go to a player and heal them when their health is low.
    /// FSMAction's are designed to be inherited, and extended from the ActionUpdate method to provide functionality to the action
    /// </summary>
    public abstract class FSMAction : MonoBehaviour
    {

        private bool _actionActivated = false;

        public bool Activated => _actionActivated;

        protected virtual void Update()
        {
            if (_actionActivated)
                ActionUpdate();
        }

        protected virtual void Start() { }
        protected virtual void OnDestroy() { }


        /// <summary>
        /// Implemented in FSMActions when it needs to be updated every tick.
        /// </summary>
        protected virtual void ActionUpdate() { }

        /// <summary>
        /// Implemented in FSMActions when it needs to do something on startup.
        /// EX: Change Navigation Algorithm
        /// </summary>
        protected virtual void OnActionEnabled() { }

        /// <summary>
        /// Implemented in FSMActions when it needs to do something when disabled.
        /// EX: Change Navigation Algorithm
        /// </summary>
        protected virtual void OnActionDisabled() { }

        public void ActivateAction()
        {
            _actionActivated = true;
            OnActionEnabled();
        }

        public void DisableAction()
        {
            _actionActivated = false;
            OnActionDisabled();
        }
    }
}
