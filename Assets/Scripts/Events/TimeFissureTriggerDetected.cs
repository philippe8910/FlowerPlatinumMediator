namespace Events
{
    public class TimeFissureTriggerDetected
    {
        public bool isTrigger;

        public TimeFissureTriggerDetected(bool value)
        {
            isTrigger = value;
        }
    }
}