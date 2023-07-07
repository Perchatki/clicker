using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public static Resources instance;
    public List<Resource> resources;
    void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }

    public void AddResource(Resource resource)
    {

        int index = resources.FindIndex(delegate (Resource res) { return resource.type == res.type;});

        resources[index] = new(resources[index].type, resources[index].count + resource.count, null);

        ResourceTextUpdater.instance.UpdateText();
    }

    public void RemoveResources(Resource[] resource)
    {
        for (int i = 0; i < resource.Length; i++)
        {
            for (int j = 0; j < resources.Count; j++)
            {
                if (resources[j].type != resource[i].type) continue;

                resources[j] = new(resource[i].type, resources[j].count - resource[i].count, null);
            }
        }

        ResourceTextUpdater.instance.UpdateText();
    }

}
