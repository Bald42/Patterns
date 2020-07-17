namespace BulletParametrs
{
    /// <summary>
    /// Пуля не имеет время жизни
    /// </summary>
    public class BulletImmortal : ILifeTime
    {
        float ILifeTime.Value()
        {
            return -1f;
        }
    }
}