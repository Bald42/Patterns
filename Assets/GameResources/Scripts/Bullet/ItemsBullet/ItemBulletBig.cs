using BulletParametrs;
using Enums;

/// <summary>
/// Большая пуля
/// </summary>
public class ItemBulletBig : IBulletFactory
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
        return new BulletBig();
    }

    ISpeed IBulletFactory.GetSpeed()
    {
        return new BulletSlow();
    }

    TypeBullet IBulletFactory.GetType()
    {
        return TypeBullet.BulletBig;
    }
}