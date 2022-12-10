namespace TuningTrouble;

public class MarkerLocator
{
    public Marker? Find(string buffer, int windowSize)
    {
        for (int characterIndex = 0; characterIndex < buffer.Length - windowSize; characterIndex++)
        {
            var window = buffer.Substring(characterIndex, windowSize);

            if (this.ContainsOnlyDistinctCharacters(window))
            {
                return new Marker(Position: characterIndex + windowSize, window);
            }
        }

        return null;
    }

    public bool ContainsOnlyDistinctCharacters(string window)
        => window.Distinct().Count() == window.Length;
}