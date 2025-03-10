using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject _leftHand;
    [SerializeField] private GameObject _rightHand;

    private HandAnimationState _leftHandState = HandAnimationState.Start_Only;
    private HandAnimationState _rightHandState = HandAnimationState.Start_Only;
    
    public HandAnimationState LeftHandState
    {
        set
        {
            if (_leftHandState == value) return;
            
            Debug.Log($"Left Hand State: {_leftHandState}");
            switch (value)
            {
                case HandAnimationState.Default:
                {
                    LeftHandAnimator.SetTrigger("Default Mode");
                    _leftHandState = HandAnimationState.Default;
                } break;
                case HandAnimationState.Holding:
                {
                    LeftHandAnimator.SetTrigger("Carrying Mode");
                    _leftHandState = HandAnimationState.Holding;
                } break;
                case HandAnimationState.Pointing:
                {
                    LeftHandAnimator.SetTrigger("UI Interaction Mode");
                    _leftHandState = HandAnimationState.Pointing;
                } break;
            }
        }
    }
    
    public HandAnimationState RightHandState
    {
        set
        {
            if (_rightHandState == value) return;
            
            Debug.Log($"Right Hand State: {_rightHandState}");
            switch (value)
            {
                case HandAnimationState.Default:
                {
                    RightHandAnimator.SetTrigger("Default Mode");
                    _rightHandState = HandAnimationState.Default;

                    RightHandAnimator.ResetTrigger("Carrying Mode");
                    RightHandAnimator.ResetTrigger("UI Interaction Mode");
                } break;
                case HandAnimationState.Holding:
                {
                    RightHandAnimator.SetTrigger("Carrying Mode");
                    _rightHandState = HandAnimationState.Holding;

                    RightHandAnimator.ResetTrigger("Default Mode");
                    RightHandAnimator.ResetTrigger("UI Interaction Mode");
                } break;
                case HandAnimationState.Pointing:
                {
                    RightHandAnimator.SetTrigger("UI Interaction Mode");
                    _rightHandState = HandAnimationState.Pointing;

                    RightHandAnimator.ResetTrigger("Default Mode");
                    RightHandAnimator.ResetTrigger("Carrying Mode");
                } break;
            }
        }
    }
    
    private Animator _leftHandAnimator;
    private Animator LeftHandAnimator => _leftHandAnimator ?? (_leftHandAnimator = _leftHand.GetComponent<Animator>());

    private Animator _rightHandAnimator;
    private Animator RightHandAnimator => _rightHandAnimator ?? (_rightHandAnimator = _rightHand.GetComponent<Animator>());
}
