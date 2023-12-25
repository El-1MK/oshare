using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRater : MonoBehaviour
{
    private int nbStars;
    private System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
        nbStars = 0;
        rand = new System.Random();
        foreach (Transform child in transform) child.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetStars(int newNbStars) {
      transform.GetChild(nbStars).gameObject.SetActive(false);
      nbStars = newNbStars % 5;
      transform.GetChild(nbStars).gameObject.SetActive(true);
    }

    public void RandomRating() {
        Debug.Log("foo");
        this.SetStars(rand.Next());   
    }
}
