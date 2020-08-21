using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputData inputData;

    void Update()
    {
        WriteInputData();
    }

    void WriteInputData()
    {
        inputData._isPressed = Input.GetMouseButtonDown(0);
        inputData._isHeld = Input.GetMouseButton(0);
        inputData._isReleased = Input.GetMouseButtonUp(0);
    }
}
