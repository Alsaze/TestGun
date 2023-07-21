using Unity.VisualScripting;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private PlayerInputAction _playerInputActions;
    // public static Action<> OnShot;
    private void Awake()
    {
        _playerInputActions = new PlayerInputAction();
        _playerInputActions.Enable();
    }

    public Vector2 GetMovmentVector2Normalized()
    {
        Vector2 inputVector = _playerInputActions.Player.Movment.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    public MouseButton GetShot()
    {
        MouseButton inputMouseButton = _playerInputActions.Player.Fire.ReadValue<MouseButton>();
        return inputMouseButton;
    }
}
