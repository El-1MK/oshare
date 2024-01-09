using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShaking : MonoBehaviour
{

    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;


    // Start is called before the first frame update
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold,2);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold
        && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {
            //déclencher la randomization de la tenue
            timeSinceLastShake = Time.unscaledTime;
        }
    }
}
