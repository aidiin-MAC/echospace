using UnityEngine;
using Unity.Mathematics;
using System.Collections.Generic;

public class FootstepController : MonoBehaviour
{
    public int groundTerrain;
    public Rigidbody myRigidbody;
    public List<AudioClip> placeholderClips;

    /*public Lists mySoundBanks;

    public int listCount;*/
    public AudioClip chosenClip;
    public float timer;
    public float cooldownTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundTerrain = 0;
        timer = 0;
        cooldownTime = .20F;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 0)
        {

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
