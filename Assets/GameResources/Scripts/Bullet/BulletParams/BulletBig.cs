namespace BulletParametrs
{
    /// <summary>
    /// Большой размер пули
    /// </summary>
    public class BulletBig : IScale
    {
        float IScale.Value()
        {
            return 1f;
        }
    }
}