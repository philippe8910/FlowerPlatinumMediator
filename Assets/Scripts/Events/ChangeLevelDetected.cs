using System;

namespace Events
{
    public class ChangeLevelDetected
    {
        public Action exitAction;
        public bool isFadeIn;

        public ChangeLevelDetected(Action action , bool _isFadeIn)
        {
            exitAction = action;
            isFadeIn = _isFadeIn;
        }
    }
}