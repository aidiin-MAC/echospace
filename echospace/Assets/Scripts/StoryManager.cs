using UnityEngine;
using System.Collections.Generic;


public class StoryManager : MonoBehaviour
{
    public int chapter;
    public float timer;
    [SerializeField] float gameTimeLimit;

    public bool altFootstep;
    public bool echo;

    public List<GameObject> Area1;
    public List<GameObject> Area2;
    public List<GameObject> Area3;

    public List<AudioClip> NarrativeClips;

    private FootstepController Footsteps;
    private GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chapter = 0;
        timer = gameTimeLimit;
        altFootstep = false;
        echo = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        Footsteps = Player.GetComponent<FootstepController>();
    }
    [ContextMenu("IncrementChapter")]
    public void IncrementChapter()
    {
        chapter++;
        ChapterStart();
    }
    void ChapterStart()
    {
        switch (chapter)
        {
            case 0:
                break;
            default:
                break;
        }
    }

    public void EffectToggle(string name)
    {
        switch (name)
        {
            default:
                break;
            case "echo":
                if (echo)
                {
                    echo = false;
                }
                else
                {
                    echo = true;
                }
                break;
            case "footstep":
                if (altFootstep)
                {
                    altFootstep = false;
                }
                else
                {
                    altFootstep = true;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (chapter)
        {
            default:
                break;
            case 0:
                for (int i = 0; i < Area1.Capacity; i++)
                {
                    Area1[i].SetActive(false);
                }
                for (int i = 0; i < Area2.Capacity; i++)
                {
                    Area2[i].SetActive(false);
                }
                for (int i = 0; i < Area3.Capacity; i++)
                {
                    Area3[i].SetActive(false);
                }
                break;
            case 1:
            case 2:
                if (altFootstep)
                {
                    Footsteps.groundTerrain = 6;
                }
                else
                {
                    Footsteps.groundTerrain = 0;
                }
                break;
            case 3:
            case 4:
                if (altFootstep)
                {
                    Footsteps.groundTerrain = 2;
                }
                else
                {
                    Footsteps.groundTerrain = 1;
                }
                break;
            case 5:
            case 6:
                break;
        }
        if (chapter != 0) 
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                chapter = 0;
                ChapterStart();
            }
        }
    }
}
