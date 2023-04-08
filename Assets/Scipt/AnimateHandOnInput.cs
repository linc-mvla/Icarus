using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    //Input Maps
    public InputActionProperty pinchAction;
    public InputActionProperty gripAction;

    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //sense trigger and play anim
        float triggerVal = pinchAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerVal);

        //sense grab and play anim
        float gripVal = gripAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripVal);
    }
}
