namespace BulletParametrs
{
    /// <summary>
    /// Пуля имеет время жизни
    /// </summary>
    public class BulletMortal : ILifeTime
    {
        float ILifeTime.Value()
        {
            return 3f;
        }
    }
}