using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingScreenLoader : MonoBehaviour
{
    public List<GameObject> selectors;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
       foreach (GameObject selector in selectors)
       {
          selector.GetComponent<SlideMenuSelection>().Reset();
          selector.GetComponent<SlideMenuSelection>().CenterChildren();
       } 
    }
}
