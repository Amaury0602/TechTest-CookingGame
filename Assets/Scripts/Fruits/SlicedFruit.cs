using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Fruit
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public class SlicedFruit : MonoBehaviour
    {
        /// <summary>
        /// This script allows us to tag fruits and set a specific ingredient for the pot to receive
        /// </summary>
        public Type type;
        [HideInInspector] public bool alreadyCounted = false;

        [Header("Reference the local Event")]
        [SerializeField] private LocalEvent onFruitDestroyed;

        public enum Type
        {
            Apple, Avocado
        }

        public void CountInPot()
        {
            alreadyCounted = true;
        }

        public void DestroyFruitOnTimerEnds()
        {
            onFruitDestroyed.Raise(transform.position);
            Destroy(gameObject);
        }
    }
}
