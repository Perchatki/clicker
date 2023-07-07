using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceLevel : MonoBehaviour
{
    public int CurrentLevel { get; private set; }

    [SerializeField] public Level[] levels;
        

    public void LevelUp(int count = -1)
    {
        if (count >= 0) CurrentLevel = count;
        else CurrentLevel++;

    }




}
