using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Click : MonoBehaviour
{

    [SerializeField] private Resource[] resources;

    [SerializeField] private ResourceTextUpdater resourceTextUpdater;

    // Start is called before the first frame update
    private void Start()
    {
        foreach (Resource resource in resources)
        {
            GetComponent<Button>().onClick.AddListener(() =>
                Resources.instance.AddResource(resource));
        }
        GetComponent<Button>().onClick.AddListener(resourceTextUpdater.UpdateText);

    }
}
