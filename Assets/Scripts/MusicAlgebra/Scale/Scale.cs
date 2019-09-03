namespace MusicAlgebra
{
    public class Scale
    {
        private ScaleType _scaleType;
        private Pitch[] _pitches;
        
        public ScaleType scaleType => _scaleType;
        public Pitch[] pitches => _pitches;

        public Scale(ScaleType scaleType, Pitch[] pitches)
        {
            _scaleType = scaleType;
            _pitches = pitches;
        }
    }
}