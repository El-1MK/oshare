using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingManager : MonoBehaviour
{
    public List<StarRater> raters;
    public RatingScreenLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        RatingsUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomUpdate()
    {
        foreach (StarRater rater in raters)
        {
            rater.RandomRating(); 
        }
    }

    public void RatingsUpdate()
    {
        Cloth[] outfit = loader.GetOutfit();
        raters[0].ColorRating(outfit);
        raters[1].PatternRating(outfit);
        raters[2].OriginalityRating(outfit);
        raters[3].VibeRating(outfit);
    }

    public int GetGlobalNote()
    {
        int res = 0;
        foreach(StarRater starRater in raters)
        {
            res+=starRater.nbStars;
        }

        return res;
    }
}
