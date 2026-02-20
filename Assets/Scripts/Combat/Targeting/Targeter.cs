using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public List<Target> targets = new List<Target>();

    private void OnTriggerEnter(Collider other)
    {
        Target target = other.GetComponent<Target>();

        if (target == null) return;

        targets.Add(target);


        //targets.Add(other.GetComponent<Target>());
        //Debug.Log(other.name);
    }

    private void OnTriggerExit(Collider other)
    {

        targets.Remove(other.GetComponent<Target>());
        Debug.Log(other.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
