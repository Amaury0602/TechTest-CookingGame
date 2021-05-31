using UnityEngine;

namespace WorldSpaceUI
{
    public class DifficultySelectorUI : MonoBehaviour
    {
        [Header("Event triggered")]
        [SerializeField] private IntEvent OnDifficultySelected;

        public void SelectDifficulty(int difficultyIndex)
        {
            OnDifficultySelected.Raise(difficultyIndex);
        }
    }
}

