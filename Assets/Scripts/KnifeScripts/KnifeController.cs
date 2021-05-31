using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Knife 
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public class KnifeController : MonoBehaviour
    {
        /// <summary>
        /// Check this to ensure that the player holds the knife and that it can cut fruits
        /// </summary>
        public bool CanCut => grabHandler.isSelected;
        [SerializeField] private LocalEvent OnSlice;

        [Header("Layer Mask")]
        [SerializeField] private LayerMask handLayer;
        private XRBaseInteractor handInteractor;

        private XRGrabInteractable grabHandler;

        void Start()
        {
            grabHandler = GetComponent<XRGrabInteractable>();
            StickToHandOnSpawn();
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Fruit.Sliceable>() != null)
            {
                if (CanCut)
                {
                    collision.gameObject.GetComponent<Fruit.Sliceable>().Slice();
                    OnSlice.Raise(collision.contacts[0].point);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }


        /// <summary>
        /// Automatically Grab the knife when instantiated by the knife block
        /// </summary>
        private void StickToHandOnSpawn()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f, handLayer);
            if (colliders.Length > 0)
            {
                if (colliders[0].GetComponent<XRBaseInteractor>() != null)
                {
                    handInteractor = colliders[0].GetComponent<XRBaseInteractor>();
                    grabHandler.interactionManager.ForceSelect(handInteractor, grabHandler);
                }
            }
        }
    }
}

