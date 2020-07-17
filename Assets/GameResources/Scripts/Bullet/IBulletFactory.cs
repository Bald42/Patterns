public interface IBulletFactory
{
    Enums.TypeBullet GetType();
    bool GetGravity();
    ISpeed GetSpeed();
    ILifeTime GetLifeTime();
    IScale GetScale();
}

public interface ISpeed
{
    float Value();
}

public interface ILifeTime
{
    float Value();
}

public interface IScale
{
    float Value();
}