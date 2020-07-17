namespace BulletParametrs
{
    /// <summary>
    /// Маленькая пуля
    /// </summary>
    public class BulletSmall : IScale
    {
        float IScale.Value()
        {
            return 0.5f;
        }
    }
}