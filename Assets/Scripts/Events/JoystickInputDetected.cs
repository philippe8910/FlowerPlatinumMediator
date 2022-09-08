using UnityEngine;

namespace Events
{
    public class JoystickInputDetected
    {
        public Vector2 input;
        
        public JoystickInputDetected(Vector2 _input)
        {
            input = _input;
        }
    }
}