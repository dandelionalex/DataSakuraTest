namespace Zoo.Signals
{
    public class ScoresUpdatedSignal
    {
        public int PreysDied { get; }
        public int PredatorsDied { get; }

        public ScoresUpdatedSignal( int preysDied, int predatorsDied )
        {
            PreysDied       = preysDied;
            PredatorsDied   = predatorsDied;
        }
    }
}
