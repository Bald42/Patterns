using BulletParametrs;
using Enums;

/// <summary>
/// Маленькая пуля
/// </summary>
public class ItemBulletSmall : IBulletFactory
{
    bool IBulletFactory.GetGravity()
    {
        return true;
    }

    ILifeTime IBulletFactory.GetLifeTime()
    {
        return new BulletMortal();
    }

    IScale IBulletFactory.GetScale()
    {
        return new BulletSmall ();
    }

    ISpeed IBulletFactory.GetSpeed()
    {
        return new BulletFast();
    }

    TypeBullet IBulletFactory.GetType()
    {
        return TypeBullet.BulletSmall;
    }
}