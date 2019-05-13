namespace Repeater.States
{
    public interface IState
    {
        float Time { get; set; }

        bool Ended(float objectSpawnTime);
    }
}