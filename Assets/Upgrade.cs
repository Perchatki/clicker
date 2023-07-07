using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] ResourceLevel level;
    [SerializeField] GameObject costPrefab;
    [SerializeField] GameObject costs;
    [SerializeField] Animator timer;
    [SerializeField] TMP_Text text;

    private void Start()
    {
        ChangePrice();
    }

    public void Upgrade_()
    {
        if (SufficiencyCheck())
        {
            Resources.instance.RemoveResources(level.levels[level.CurrentLevel].nextLevelCost);

            level.LevelUp();

            ChangePrice();

            ChangeStats();
        }
    }


    public bool SufficiencyCheck()
    {
        Level l = level.levels[level.CurrentLevel];
        for (int i = 0; i < l.nextLevelCost.Length; i++)
        {
            foreach (Resource res in Resources.instance.resources) 
            {
                if (res.type != l.nextLevelCost[i].type) continue;

                if (res.count < l.nextLevelCost[i].count) return false;
            }
        }

        if (l.nextLevelCost.Length <= 0) return false;

        return true;
    }

    public void ChangeStats()
    {
        timer.SetFloat("speed", 1 / level.levels[level.CurrentLevel].time);

        text.text =  $"{level.levels[level.CurrentLevel].product} piece\n{Math.Round(level.levels[level.CurrentLevel].time,1)} second";
    }

    public void ChangePrice()
    {
        for (int i = 0; i < costs.transform.childCount; i++)
        {
            Destroy(costs.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < level.levels[level.CurrentLevel].nextLevelCost.Length; i++)
        {
            GameObject cost = Instantiate(costPrefab, costs.transform);

            cost.transform.GetChild(0).GetComponent<TMP_Text>().text = level.levels[level.CurrentLevel].nextLevelCost[i].count.ToString();
            cost.transform.GetChild(1).GetComponent<Image>().sprite = level.levels[level.CurrentLevel].nextLevelCost[i].image;

            LayoutRebuilder.ForceRebuildLayoutImmediate(cost.transform.parent.GetComponent<RectTransform>());
        }
    }


}

//1. проверка достаточного количества ресурсов
//2. изъятие ресурсов через метод из Resources
//3. изменение скорости и количества ресурсов
//4. изменение скорости ползунка
//5. изменение цены
//6. изменение текста и картинок