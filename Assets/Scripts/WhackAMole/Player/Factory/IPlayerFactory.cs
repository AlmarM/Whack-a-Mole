namespace WAM.WhackAMole.Player.Factory
{
    public interface IPlayerFactory
    {
        IPlayerController CreatePlayerController();
    }
}