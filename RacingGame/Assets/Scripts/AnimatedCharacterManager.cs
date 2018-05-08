using UnityEngine;

public class AnimatedCharacterManager : MonoBehaviour {

    [SerializeField]
    TrafficLightController trafficLightScript;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        trafficLightScript.OnRaceStart += announceRaceStart;
    }

    void announceRaceStart()
    {
        animator.SetTrigger("startRace");
        Destroy(gameObject,10f);
    }
}
