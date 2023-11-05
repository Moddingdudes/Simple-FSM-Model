using UnityEngine;

namespace CyberneticStudios.FSM
{
    /// <summary>
    /// A decision state for an FSM model.
    /// This class should be inherited and invoke the ChangeDecisionStateInternal function when a decision change is made.
    /// FSMDecision's are used for FSM's and make decisions for state changes.
    /// </summary>
    public abstract class FSMDecision : MonoBehaviour
    {
        [Header("FSMDecision Settings")]
        [SerializeField] private bool _flipDecision = false; //Flips decision via a NOT operation. If the decision is determined false, it will now be true

        public event System.Action<bool> OnDecisionStateChanged;

        protected virtual void Start() { }
        protected virtual void OnDestroy() { }
        protected virtual void Update()
        {
            OnDecisionUpdate();
        }

        protected virtual void OnDecisionUpdate() { }

        protected void ChangeDecisionStateInternal(bool decisionState)
        {
            OnDecisionStateChanged?.Invoke(_flipDecision ? !decisionState : decisionState);
        }
    }
}
