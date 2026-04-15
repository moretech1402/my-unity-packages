namespace MC.Core.Unity.Inputs.Context
{
    public struct InputContextChangedEvent
    {
        public readonly InputContext Context;
        
        public InputContextChangedEvent(InputContext context)
        {
            Context = context;
        }
    }
}