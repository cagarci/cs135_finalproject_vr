using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public bool DeadBool;
    public bool PlayerDeadBool;
    public bool InSightBool;
    public bool InPresenceBool;
    public bool PatrollingBool;
    public bool InRangeBool;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
