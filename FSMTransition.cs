using UnityEngine;

namespace CyberneticStudios.FSM
{
    /// <summary>
    /// An FSMTransition allows an FSM model to go from one state to another.
    /// FSMTransition's are unidirectional meaning they can only go from one state to another state when the FSMDecision becomes true, and does not go back when it becomes false
    /// </summary>
    public class FSMTransition : MonoBehaviour
    {
        [Header("FSMTransition Settings")]
        [SerializeField] private FSMDecision _decision;
        [SerializeField] private FSMState _fromState;
        [SerializeField] private FSMState _toState;

        //Passes in the before state and after state
        public event System.Action<FSMState, FSMState> OnTransitionStateChanged;

        private void Awake()
        {
            _decision.OnDecisionStateChanged += OnDecisionStateChanged;
        }

        private void OnDestroy()
        {
            _decision.OnDecisionStateChanged -= OnDecisionStateChanged;
        }

        private void OnDecisionStateChanged(bool decisionState)
        {
            if (decisionState)
                OnTransitionStateChanged?.Invoke(_fromState, _toState);
        }
    }
}
