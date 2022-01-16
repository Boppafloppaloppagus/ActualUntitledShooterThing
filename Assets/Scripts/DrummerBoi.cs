using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrummerBoi : MonoBehaviour
{
    // Start is called before the first frame update
    // I guess I'm just gonna establish a metric for one beat or something for now, anything worth doing is worth doing poorly. - 12/15/21.
    AudioClip probablySomeFireShit;
    AudioSource noiseMachine;
    int boopsPerMinute;
    float tehUnitOBeat;
    float totalBeets;
    float timeSinceLastBeat;
    float timeSinceStart;
    bool alreadyFiredThisBeat;
    void Start()
    {
        totalBeets = probablySomeFireShit.length / (boopsPerMinute);
        tehUnitOBeat = (1 / totalBeets) * probablySomeFireShit.length;
        timeSinceLastBeat = 0;
    }

    // Update is called once per frame
    // In order to stay synced to the song, I will need to check against the current time of the song, if i merely use some sequence to determine the beat there is a possibility calculating the beat just using the delta time
    //will be wrong.
    void Update()
    {
        timeSinceLastBeat += Time.deltaTime;
        if (timeSinceLastBeat >= tehUnitOBeat)
        {
            timeSinceLastBeat = noiseMachine.time % tehUnitOBeat;
            //A beat transpired and we should do something.
        }
    }
}
