using UnityEngine;

[CreateAssetMenu(fileName ="Input_Data")]

public class InputData : ScriptableObject
{
    public bool _isPressed;
    public bool _isHeld;
    public bool _isReleased;
}
