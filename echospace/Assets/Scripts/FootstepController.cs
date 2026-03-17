using UnityEngine;
using Unity.Mathematics;
using System.Collections.Generic;

public class FootstepController : MonoBehaviour
{
    //Ground Terrain is a variable to control which sound bank is used
    public int groundTerrain;
    public Transform myTransform;
    public Dictionary<int, AudioClip> clipList;
    
    //Footstep Soundbanks
    public List<AudioClip> placeholderClips;

    //Variables for determining movement speed
    public float oldX;
    public float oldZ;
    public float deltaX;
    public float deltaZ;
    public float deadZone;
    
    /*public Lists mySoundBanks;

    public int listCount;*/
    public AudioClip chosenClip;
    public AudioSource footstepSource;
    public float timer;
    public float cooldownTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundTerrain = 0;
        timer = cooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Determines movement rate
        deltaX = myTransform.position.x - oldX;
        deltaZ = myTransform.position.z - oldZ;
        oldX = myTransform.position.x;
        oldZ = myTransform.position.z;

        //Plays footstep sound after a cooldown while moving, tied to movement speed
        if (timer < 0)
        {
            footstepSource.generator = chosenClip;
            footstepSource.Play();
            timer = cooldownTime;
            Debug.Log("footstep");

            //Should be changed to use a range based on how many sound clips are in the current sound bank
            chosenClip = placeholderClips[UnityEngine.Random.Range(0, 2)];
        }
        else
        {
            if (math.abs(deltaX) > deadZone || math.abs(deltaZ) > deadZone)
            {
                timer -= math.abs(deltaX)+math.abs(deltaZ);
            }
        }  
            

        //WIP code to switch sound banks below

        /*if (math.abs(myRigidbody.linearVelocity.x) > 1 | math.abs(myRigidbody.linearVelocity.y) > 1)
        {
            switch (groundTerrain)
            {
                case 0:
                    GetListItem("placeholder");
                    break;
                default:
                    groundTerrain = 0;
                    Debug.Log("null ground terrain");
                    break;
            }
        }*/

    }


}
