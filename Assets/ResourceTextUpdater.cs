using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceTextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text[] resourceTexts;

    public static ResourceTextUpdater instance;

    void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;

        UpdateText();
        UpdateText();
    }

    public void UpdateText()
    {
        for (int i = 0; i < resourceTexts.Length; i++)
        {
            resourceTexts[i].text = Resources.instance.resources[i].ToString();
            LayoutRebuilder.ForceRebuildLayoutImmediate(resourceTexts[i].transform.parent.GetComponent<RectTransform>());
        }
    }
}
