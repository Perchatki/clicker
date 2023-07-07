using System;

[Serializable]
public struct Level
{
    public Resource[] nextLevelCost;
    public Resource product;
    public float time;

    public Level(Resource[] nextLevelCost, Resource product, float time)
    {
        this.nextLevelCost = nextLevelCost;
        this.product = product;
        this.time = time;
    }
}
