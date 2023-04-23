using WAM.WhackAMole.Scores.Serialization;

namespace WAM.WhackAMole.Scores
{
    public class ScoreHandler : IScoreHandler
    {
        public int Score { get; private set; }

        private readonly IScoreSerializer _scoreSerializer;
        private readonly IScoreDeserializer _scoreDeserializer;

        public ScoreHandler(IScoreSerializer scoreSerializer, IScoreDeserializer scoreDeserializer)
        {
            _scoreSerializer = scoreSerializer;
            _scoreDeserializer = scoreDeserializer;
        }

        public void AddPoint()
        {
            Score++;
        }

        public void Reset()
        {
            Score = 0;
        }

        public void SaveScore(HighscoreEntry entry)
        {
            _scoreSerializer.SaveScore(entry);
        }
    }
}