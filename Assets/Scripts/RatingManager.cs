using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingManager : MonoBehaviour
{
    public List<GameObject> raters;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomUpdate()
    {
        foreach (GameObject rater in raters)
        {
            rater.GetComponent<StarRater>().RandomRating(); 
        }
    }
}
