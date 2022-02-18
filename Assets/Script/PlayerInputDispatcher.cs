using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputDispatcher : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    [SerializeField] EntityMovement _movement;
    [SerializeField] EntityFire _fire;
    [SerializeField] Health _health;

    [SerializeField] InputActionReference _pointerPosition;
    [SerializeField] InputActionReference _moveJoystick;
    [SerializeField] InputActionReference _fireButton;
    [SerializeField] InputActionReference _shieldButton;

    Coroutine MovementTracking { get; set; }

    Vector3 ScreenPositionToWorldPosition(Camera c, Vector2 cursorPosition) => _mainCamera.ScreenToWorldPoint(cursorPosition);

    private void Start()
    {

        // binding
        _fireButton.action.started += FireInput;
       
        _shieldButton.action.started += ShieldInput;
        _shieldButton.action.canceled += ShieldInputCancel;

        _moveJoystick.action.started += MoveInput;
        _moveJoystick.action.canceled += MoveInputCancel;
    }

    

    private void OnDestroy()
    {
        _fireButton.action.started -= FireInput;
        _moveJoystick.action.started -= MoveInput;
        _moveJoystick.action.canceled -= MoveInputCancel;

        _shieldButton.action.started -= ShieldInput;
        _shieldButton.action.canceled -= ShieldInputCancel;
    }

    private void ShieldInput(InputAction.CallbackContext obj)
    {
        _fire.canFire = false;
        _health.hasShield = true;
        Debug.Log("fire shield");
    }

    private void ShieldInputCancel(InputAction.CallbackContext obj)
    {
        _fire.canFire = true;
        _health.hasShield = false;
        Debug.Log("end shield");
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        if (MovementTracking != null) return;

        MovementTracking = StartCoroutine(MovementTrackingRoutine());
        IEnumerator MovementTrackingRoutine()
        {
            while (true)
            {
                _movement.PrepareDirection(obj.ReadValue<Vector2>());
                yield return null;
            }
            yield break;
        }
    }

    private void MoveInputCancel(InputAction.CallbackContext obj)
    {
        if (MovementTracking == null) return;
        _movement.PrepareDirection(Vector2.zero);
        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }

    private void FireInput(InputAction.CallbackContext obj)
    {
        float fire = obj.ReadValue<float>();
        if(fire==1)
        {
            _fire.FireBullet(2);
        }
    }

}
