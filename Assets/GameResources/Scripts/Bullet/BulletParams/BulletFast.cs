namespace BulletParametrs
{
    /// <summary>
    /// Быстрая пуля
    /// </summary>
    public class BulletFast : ISpeed
    {
        float ISpeed.Value()
        {
            return 200f;
        }
    }
}