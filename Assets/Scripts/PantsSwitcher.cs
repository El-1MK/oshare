using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantsSwitcher : MonoBehaviour
{
    public Transform inner, outer;
    bool state;

    // Start is called before the first frame update
    void Start()
    {
       state = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
      transform.SetParent(state? outer : inner);
      transform.SetSiblingIndex(1);
      state = !state;
    }
}
