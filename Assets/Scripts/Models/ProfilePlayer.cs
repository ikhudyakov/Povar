using Tools;

namespace Models
{
    public class ProfilePlayer
    {
        public ProfilePlayer()
        {
            CurrentState = new SubscriptionProperty<GameState>();
        }

        public SubscriptionProperty<GameState> CurrentState { get; }
    }
}