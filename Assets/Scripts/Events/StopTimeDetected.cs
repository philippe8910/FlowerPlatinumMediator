namespace Events
{
    public class StopTimeDetected
    {
        public bool isStop;

        public StopTimeDetected(bool _isStop)
        {
            isStop = _isStop;
        }
    }
}