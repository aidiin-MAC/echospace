using UnityEngine;
using Unity.Mathematics;
using System.Collections.Generic;

public class FootstepController : MonoBehaviour
{
    //Ground Terrain is a variable to control which sound bank is used
    public int groundTerrain;
    public Transform myTransform;
    public Dictionary<int, AudioClip> clipList;

    //chrissy
    //add more lists for cave/lab
    //this is prob like a pointer for the other groundTerrain lists
    public List<AudioClip> activeClips; //grass, stone, etc. clips

    //Footstep Soundbanks
    public List<AudioClip> placeholderClips; //current placeholders, the default
    //groundTerrain
    public List<AudioClip> grassClips;
    public List<AudioClip> stoneClips;
    public List<AudioClip> puddleClips;
    public List<AudioClip> tileClips;
    public List<AudioClip> glassClips;
    public List<AudioClip> stairsClips;

    public List<AudioClip> riverClips;

    //gravel, shrub hits?


    //Variables for determining movement speed
    public float oldX;
    public float oldZ;
    public float deltaX;
    public float deltaZ;
    public float deadZone;

    /*public Lists mySoundBanks;

    public int listCount;*/
    public AudioClip chosenClip; //the clip that will be played
    public AudioSource footstepSource;
    public float timer;
    public float cooldownTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundTerrain = 0;
        //0 = grass, 1 = stone, 2 = puddle, 3 = tile, 4 = glass, 5 = stairs
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
            // footstepSource.generator = chosenClip;
            // footstepSource.Play();

            switch (groundTerrain)
            {
                case 0:
                    //GetListItem("placeholder");
                    //footstepSource.generator = grassSound; 

                    activeClips = grassClips;
                    Debug.Log("grass terrain");
                    break;
                case 1:
                    //getListItem("stoneSound"); //?
                    activeClips = stoneClips;
                    Debug.Log("cave terrain");
                    break;
                case 2:
                    //getListItem("puddleSound");
                    activeClips = puddleClips;
                    Debug.Log("puddle/wet terrain");
                    break;
                case 3:
                    //getListItem("tileSound");
                    activeClips = tileClips;
                    Debug.Log("lab terrain");
                    break;
                case 5:
                    //getListItem("stairsSound");
                    activeClips = stairsClips;
                    Debug.Log("stairs terrain");
                    break;
                case 6:
                    //getListItem("riverSound");
                    activeClips = riverClips;
                    Debug.Log("edge of the river terrain");
                    break;
                default:
                    //groundTerrain = 0; //default is back to case 0?
                    activeClips = placeholderClips;
                    Debug.Log("null ground terrain");
                    break;
            }

            timer = cooldownTime;
            Debug.Log("footstep");

            //Should be changed to use a range based on how many sound clips are in the current sound bank
            chosenClip = activeClips[UnityEngine.Random.Range(0, activeClips.Capacity)];
            footstepSource.generator = chosenClip;
            footstepSource.Play();
        }
        else
        {
            if (math.abs(deltaX) > deadZone || math.abs(deltaZ) > deadZone)
            {
                timer -= math.abs(deltaX) + math.abs(deltaZ);
            }
        }


        //WIP code to switch sound banks below

        //if player is moving(?)
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
