public class RandomService
{
    public int RandomNumber()
    {
        Random rnd = new Random();
        return rnd.Next();
    }
} 