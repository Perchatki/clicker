using System.Collections;
using UnityEngine;

public class Saving : MonoBehaviour
{

    [SerializeField] ResourceLevel[] levels;
    [SerializeField] Upgrade[] upgrades;
    private void Start()
    {
        Load();
        ResourceTextUpdater.instance.UpdateText();

        foreach (Upgrade upgrade in upgrades) 
        {
            upgrade.ChangePrice();
            upgrade.ChangeStats();
        }


        _ = StartCoroutine(Save());
    }

    private IEnumerator Save()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);

            PlayerPrefs.SetInt("apples", Resources.instance.resources[0].count);
            PlayerPrefs.SetInt("berries", Resources.instance.resources[1].count);
            PlayerPrefs.SetInt("bread", Resources.instance.resources[2].count);
            PlayerPrefs.SetInt("cheese", Resources.instance.resources[3].count);
            PlayerPrefs.SetInt("meat", Resources.instance.resources[4].count);

            PlayerPrefs.SetInt("applesLevel", levels[0].CurrentLevel);
            PlayerPrefs.SetInt("berriesLevel", levels[1].CurrentLevel);
            PlayerPrefs.SetInt("breadLevel", levels[2].CurrentLevel);
            PlayerPrefs.SetInt("cheeseLevel", levels[3].CurrentLevel);
            PlayerPrefs.SetInt("meatLevel", levels[4].CurrentLevel);
        }
    }


    public void Load()
    {
        Resources.instance.AddResource(new(ResourceType.apple, PlayerPrefs.GetInt("apples", 0), null));
        Resources.instance.AddResource(new(ResourceType.berry, PlayerPrefs.GetInt("berries", 0), null));
        Resources.instance.AddResource(new(ResourceType.bread, PlayerPrefs.GetInt("bread", 0), null));
        Resources.instance.AddResource(new(ResourceType.cheese, PlayerPrefs.GetInt("cheese", 0), null));
        Resources.instance.AddResource(new(ResourceType.meat, PlayerPrefs.GetInt("meat", 0), null));

        levels[0].LevelUp(PlayerPrefs.GetInt("applesLevel", 0));
        levels[1].LevelUp(PlayerPrefs.GetInt("berriesLevel", 0));
        levels[2].LevelUp(PlayerPrefs.GetInt("breadLevel", 0));
        levels[3].LevelUp(PlayerPrefs.GetInt("cheeseLevel", 0));
        levels[4].LevelUp(PlayerPrefs.GetInt("meatLevel", 0));
    }
    public void ResetProgress()
    {
        levels[0].LevelUp(0);
        levels[1].LevelUp(0);
        levels[2].LevelUp(0);
        levels[3].LevelUp(0);
        levels[4].LevelUp(0);

        for (int i = 0; i < Resources.instance.resources.Count; i++)
        {
            Resources.instance.resources[i] = new(Resources.instance.resources[i].type, 0, null);
        }
        
        ResourceTextUpdater.instance.UpdateText();

        foreach (Upgrade upgrade in upgrades)
        {
            upgrade.ChangePrice();
            upgrade.ChangeStats();
        }

        Save();
    }

    /*
    1. количество ресурсов

    2. Текущий уровень у каждой из карточек

    3. загружать количество ресурсов
    3.1. Обновить интерфейс

    4. Пройтись по каждой карточке и поменять текущий уровень
    4.1. изменение скорости и количества ресурсов
    4.2. изменение скорости ползунка
    4.3. изменение цены
    4.4. изменение текста и картинок
    */
}
