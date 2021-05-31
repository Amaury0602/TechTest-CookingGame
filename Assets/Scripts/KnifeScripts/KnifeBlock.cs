using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Knife
{
    [RequireComponent(typeof(XRSimpleInteractable), typeof(AudioSource))]
    public class KnifeBlock : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private GameObject knife;

        private AudioSource aSource;

        private XRSimpleInteractable interactionHandler;

        [SerializeField] private BaseEvent onKnifePicked;

        //This boolean prevents from triggering the onKnifePicked event every time the player picks a knife
        private bool firstKnifePicked = false;
        //Player can only pickup knife when difficulty selected
        private bool canPickupKnife = false;

        private void Start()
        {
            aSource = GetComponent<AudioSource>();
            interactionHandler = GetComponent<XRSimpleInteractable>();
            interactionHandler.selectEntered.AddListener(arg => SpawnKnife(arg.interactor));
        }

        private void SpawnKnife(XRBaseInteractor interactor)
        {
            if (!canPickupKnife) return;

            if (!firstKnifePicked)
            {
                onKnifePicked.Raise();
                firstKnifePicked = true;
            }
            Instantiate(knife, interactor.transform.position, Quaternion.identity);
            aSource.Play();
            XRGrabInteractable knifeGrab = knife.GetComponent<XRGrabInteractable>();
        }

        //Knife gets grabbable when the difficulty is selected
        //Grabbable is set to false at the end of the round, when the timer ends
        //Also firstKnifePicked is set back to false when the timer ends
        public void SetKnifeGrababble(bool grabbable)
        {
            canPickupKnife = grabbable;
            if (!grabbable) firstKnifePicked = false;
        }
    }
}

