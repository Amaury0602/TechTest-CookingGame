using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    private Animator anim;
    private ActionBasedController controller;
    private XRInteractorLineVisual interactorLine;

    void Start()
    {
        interactorLine = transform.parent.GetComponent<XRInteractorLineVisual>();
        controller = transform.parent.GetComponent<ActionBasedController>();
        anim = GetComponent<Animator>();

        controller.selectAction.action.performed += OnSelect;
        controller.selectAction.action.canceled += OnDeselect;
    }

    private void OnDeselect(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        anim.SetTrigger("Open");
        interactorLine.enabled = true;
    }

    private void OnSelect(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        anim.SetTrigger("Close");
        interactorLine.enabled = false;
    }

    private void OnDisable()
    {

        controller.selectAction.action.performed -= OnSelect;
        controller.selectAction.action.canceled -= OnDeselect;
    }
}
