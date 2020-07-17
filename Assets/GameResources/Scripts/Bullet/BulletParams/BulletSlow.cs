namespace BulletParametrs
{
    /// <summary>
    /// Медленная пуля
    /// </summary>
    public class BulletSlow : ISpeed
    {
        float ISpeed.Value()
        {
            return 100f;
        }
    }
}