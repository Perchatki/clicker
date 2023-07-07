using System;
using UnityEngine;
using UnityEngine.UI;

public enum ResourceType
{
    apple,
    berry,
    bread,
    cheese,
    meat
}

[Serializable]
public struct Resource
{
    public ResourceType type;
    public int count;
    public Sprite image;

    public Resource(ResourceType type, int count, Sprite image)
    {
        this.type = type;
        this.count = count;
        this.image = image;
    }

    public override string ToString()
    {
        return count.ToString();
    }
}
