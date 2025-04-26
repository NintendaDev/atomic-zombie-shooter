namespace Game.Gameplay.Contexts.Game
{
    public static class ScoreUseCase
    {
        public static void IncreaseScore(IGameContext context)
        {
            context.GetScore().Value += context.GetKillReward().Value;
        }
    }
}