using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    private Animator anim;
    private ActionBasedController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = transform.parent.GetComponent<ActionBasedController>();
        anim = GetComponent<Animator>();

        controller.selectAction.action.performed += OnSelectAction;
        controller.selectAction.action.canceled += OnDeselect;
    }

    private void OnDeselect(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        anim.SetTrigger("Open");
    }

    private void OnSelectAction(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        anim.SetTrigger("Close");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
