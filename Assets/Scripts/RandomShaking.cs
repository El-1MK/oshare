using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShaking : MonoBehaviour
{

    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;

    public RatingManager ratingManager;
    public SlideMenuSelection[] selectors;

    private System.Random rand;

    public GameObject[] soundPlayers;


    // Start is called before the first frame update
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold,2);
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold
        && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {
            //déclencher la randomization de la tenue
            timeSinceLastShake = Time.unscaledTime;
            GenerateNewOutfit();
        }
    }

    void GenerateNewOutfit() {
        foreach(SlideMenuSelection selector in selectors){
            selector.ChangeItem(rand.Next()%selector.nbItems);
        }
        ratingManager.RatingsUpdate();

        int globalNote = ratingManager.GetGlobalNote();

        //if(globalNote <= 4){
        //    soundPlayers[0].GetComponent<AudioSource>().Play(0);
        //}else if(globalNote <= 8){
        //    soundPlayers[1].GetComponent<AudioSource>().Play(0);
        //}else if(globalNote <= 12){
            soundPlayers[2].GetComponent<AudioSource>().Play(0);
        //}else{
        //    soundPlayers[3].GetComponent<AudioSource>().Play(0);
        //}
    }
}
