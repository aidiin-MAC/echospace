using UnityEngine;
using Unity.Mathematics;
using System.Collections.Generic;

public class FootstepController : MonoBehaviour
{
    public int groundTerrain;
    public Transform myTransform;
    public Dictionary<int, AudioClip> clipList;
    public List<AudioClip> placeholderClips;
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
        deltaX = myTransform.position.x - oldX;
        deltaZ = myTransform.position.z - oldZ;
        oldX = myTransform.position.x;
        oldZ = myTransform.position.z;
        if (timer < 0)
        {
            footstepSource.generator = chosenClip;
            footstepSource.Play();
            timer = cooldownTime;
            Debug.Log("footstep");
            chosenClip = placeholderClips[UnityEngine.Random.Range(0, 2)];
        }
        else
        {
            if (math.abs(deltaX) > deadZone || math.abs(deltaZ) > deadZone)
            {
                timer -= math.abs(deltaX)+math.abs(deltaZ);
            }
        }  
            

        
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
