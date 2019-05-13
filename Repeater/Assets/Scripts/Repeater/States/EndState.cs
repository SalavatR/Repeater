namespace Repeater.States
{
    public class EndState : IState
    {
        public float Time { get; set; }
        public bool NeedDestroyGameObject { get; }
    
        public bool Ended(float objectSpawnTime)
        {
            return true;
        }
    
        public EndState(bool needDestroyGameObject)
        {
            this.NeedDestroyGameObject = needDestroyGameObject;
            Time = UnityEngine.Time.realtimeSinceStartup;
        }
    }
}