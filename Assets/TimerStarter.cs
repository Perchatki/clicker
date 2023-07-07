using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class TimerStarter : MonoBehaviour
{
    [SerializeField] ResourceLevel level;

    public void StartTimer() => GetComponent<Animator>().SetBool("isActive", true);

    public void EndTimer()
    {
        Resources.instance.AddResource(level.levels[level.CurrentLevel].product);
        GetComponent<Animator>().SetBool("isActive", false);
    }
}
