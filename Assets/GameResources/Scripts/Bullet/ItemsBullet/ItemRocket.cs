using BulletParametrs;
using Enums;

/// <summary>
/// Ракета
/// </summary>
public class ItemRocket : IBulletFactory
{
    bool IBulletFactory.GetGravity()
    {
        return false;
    }

    ILifeTime IBulletFactory.GetLifeTime()
    {
        return new BulletImmortal();
    }

    IScale IBulletFactory.GetScale()
    {
        return new BulletSmall();
    }

    ISpeed IBulletFactory.GetSpeed()
    {
        return new BulletFast();
    }

    TypeBullet IBulletFactory.GetType()
    {
        return TypeBullet.Rocket;
    }
}