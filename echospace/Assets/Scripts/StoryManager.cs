using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections.Generic;


public class StoryManager : MonoBehaviour
{
    public int chapter;
    public float timer;

    public float sceneTimer;
    [SerializeField] float failSceneTime;
    public bool sceneTimerActive;

    [SerializeField] float gameTimeLimit;

    public int footstepId;
    public bool echo;
    public bool canMove;

    //SoundSourceAreas
    public List<GameObject> Area1;
    public List<GameObject> Area2;
    public List<GameObject> Area3;
    public List<GameObject> Area4;

    //AudioMixerPresets
    public AudioMixerSnapshot A1;
    public AudioMixerSnapshot A2;
    public AudioMixerSnapshot A3;
    public AudioMixerSnapshot End;
    public AudioMixerSnapshot Loss;

    public List<GameObject> NarrativeSequences;

    private FootstepController Footsteps;
    private GameObject Player;

    public List<GameObject> TimeWarnings;
    public List<bool> TimeWarningsPlayed;

    public bool monsterSoundPlayed;

    InputAction resetAction;
    InputAction cameraAction;
    private bool cameraReleased;
    public Animator cameraControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chapter = 0;
        timer = gameTimeLimit;
        footstepId = 0;
        canMove = false;
        echo = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        Footsteps = Player.GetComponent<FootstepController>();
        monsterSoundPlayed = false;

        resetAction = InputSystem.actions.FindAction("Reset");
        cameraAction = InputSystem.actions.FindAction("Camera");
        cameraReleased = true;
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
                timer = gameTimeLimit;
                cameraControl.SetBool("IsOverview", true);
                cameraControl.SetFloat("Blend", 0);
                break;
            case 1:
                canMove = true;
                for (int i = 0; i < Area1.Count; i++)
                {
                    Area1[i].SetActive(true);
                    Debug.Log("activated item " + i);
                }
                A1.TransitionTo(2f);
                cameraControl.SetFloat("Blend", 0);
                break;
            case 2:
                NarrativeSequences[0].SetActive(true);
                NarrativeSequences[0].GetComponent<AudioSource>().Play();
                NarrativeSequences[1].SetActive(true);
                break;
            case 3:
                for (int i = 0; i < Area2.Count; i++)
                {
                    Area2[i].SetActive(true);
                    Debug.Log("activated item " + i);
                }
                NarrativeSequences[1].SetActive(false);
                NarrativeSequences[2].SetActive(true);
                NarrativeSequences[3].SetActive(true);
                NarrativeSequences[4].SetActive(true);
                NarrativeSequences[4].GetComponent<AudioSource>().Play();
                A2.TransitionTo(2f);
                cameraControl.SetFloat("Blend", 0.25f);
                break;
            case 4:
                NarrativeSequences[3].SetActive(false);
                for (int i = 0; i < Area1.Count; i++)
                {
                    Area1[i].SetActive(false);
                }
                for (int i = 0; i < Area3.Count; i++)
                {
                    Area3[i].SetActive(true);
                    Debug.Log("activated item " + i);
                }
                break;
            case 5:
                NarrativeSequences[5].SetActive(true);
                NarrativeSequences[5].GetComponent<AudioSource>().Play();
                NarrativeSequences[6].SetActive(true);
                A3.TransitionTo(2f);
                cameraControl.SetFloat("Blend", 0.5f);
                break;
            case 6:
                NarrativeSequences[7].SetActive(true);
                NarrativeSequences[8].SetActive(true);
                NarrativeSequences[8].GetComponent<AudioSource>().Play();
                NarrativeSequences[9].SetActive(true);
                NarrativeSequences[9].GetComponent<AudioSource>().Play();
                for (int i = 0; i < Area2.Count; i++)
                {
                    Area2[i].SetActive(false);
                }
                for (int i = 0; i < Area2.Count; i++)
                {
                    Area3[i].SetActive(false);
                }
                for (int i = 0; i < Area2.Count; i++)
                {
                    Area4[i].SetActive(true);
                }
                cameraControl.SetFloat("Blend", 0.75f);
                break;
            case 7:
                NarrativeSequences[10].SetActive(true);
                NarrativeSequences[11].SetActive(true);
                NarrativeSequences[11].GetComponent<AudioSource>().Play();
                NarrativeSequences[12].SetActive(true);
                NarrativeSequences[12].GetComponent<AudioSource>().Play();
                NarrativeSequences[13].SetActive(true);
                NarrativeSequences[13].GetComponent<AudioSource>().Play();
                cameraControl.SetFloat("Blend", 1);
                break;
            case 8:
                canMove = false;
                Loss.TransitionTo(1.5f);
                sceneTimer = failSceneTime;
                break;
            case 9:
                canMove = false;
                Loss.TransitionTo(.5f);
                TimeWarnings[4].SetActive(true);
                TimeWarnings[4].GetComponent<AudioSource>().Play();
                monsterSoundPlayed = true;
                sceneTimer = failSceneTime;
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
            case "footstep0":
                footstepId = 0;
                break;
            case "footstep1":
                footstepId = 1;
                break;
            case "footstep2":
                footstepId = 2;
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
                for (int i = 0; i < Area1.Count; i++)
                {
                    Area1[i].SetActive(false);
                }
                for (int i = 0; i < Area2.Count; i++)
                {
                    Area2[i].SetActive(false);
                }
                for (int i = 0; i < Area3.Count; i++)
                {
                    Area3[i].SetActive(false);
                }
                for (int i = 0; i < Area3.Count; i++)
                {
                    Area4[i].SetActive(false);
                }
                for (int i = 0; i < TimeWarnings.Count; i++)
                {
                    TimeWarnings[i].SetActive(false);
                }
                for (int i = 0; i < TimeWarningsPlayed.Count; i++)
                {
                    TimeWarningsPlayed[i] = false;
                }
                break;

            //Forest Update
            case 1:
            case 2:
                switch (footstepId)
                {
                    case 0:
                        Footsteps.groundTerrain = 0;
                        break;
                    case 1:
                        Footsteps.groundTerrain = 6;
                        break;
                    default:
                        footstepId = 0;
                        break;
                }
                break;

            //Cave Update
            case 3:
            case 4:
                switch (footstepId)
                {
                    case 0:
                        Footsteps.groundTerrain = 1;
                        break;
                    case 1:
                        Footsteps.groundTerrain = 2;
                        break;
                    default:
                        footstepId = 0;
                        break;
                }
                break;

            //Lab Update
            case 5:
            case 6:
            case 7:
                switch (footstepId)
                {
                    case 0:
                        Footsteps.groundTerrain = 3;
                        break;
                    case 1:
                        Footsteps.groundTerrain = 4;
                        break;
                    case 2:
                        Footsteps.groundTerrain = 5;
                        break;
                    default:
                        footstepId = 0;
                        break;
                }
                break;
            case 8:
                if (sceneTimer < 12 && monsterSoundPlayed == false)
                {
                    NarrativeSequences[14].SetActive(true);
                    NarrativeSequences[14].GetComponent<AudioSource>().Play();
                    monsterSoundPlayed = true;
                }
                if (sceneTimer < 0)
                {
                    End.TransitionTo(1f);
                    SceneManager.LoadScene("GameField");
                }
                else
                {
                    sceneTimer -= Time.deltaTime;
                }
                break;
            case 9:
                if (sceneTimer < 0)
                {
                    End.TransitionTo(1f);
                    SceneManager.LoadScene("GameField");
                }
                else
                {
                    sceneTimer -= Time.deltaTime;
                }
                break;
        }
        if (chapter != 0 && chapter !=9) 
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (cameraAction.IsPressed() && cameraReleased)
                {
                    cameraReleased = false;
                    cameraControl.SetBool("IsOverview", !cameraControl.GetBool("IsOverview"));
                }
                else if (!cameraAction.IsPressed())
                {
                    cameraReleased = true;
                }
                if (resetAction.IsPressed())
                {
                    End.TransitionTo(1f);
                    SceneManager.LoadScene("GameField");
                }
            }
            else
            {
                chapter = 9;
                ChapterStart();
            }

            if (timer < 120 && TimeWarningsPlayed[0] == false)
            {
                TimeWarningsPlayed[0] = true;
                TimeWarnings[0].SetActive(true);
                TimeWarnings[0].GetComponent<AudioSource>().Play();
            }
            if (timer < 80 && TimeWarningsPlayed[1] == false)
            {
                TimeWarningsPlayed[1] = true;
                TimeWarnings[1].SetActive(true);
                TimeWarnings[1].GetComponent<AudioSource>().Play();
            }
            if (timer < 40 && TimeWarningsPlayed[2] == false)
            {
                TimeWarningsPlayed[2] = true;
                TimeWarnings[2].SetActive(true);
                TimeWarnings[2].GetComponent<AudioSource>().Play();
            }
            if (timer < 10 && TimeWarningsPlayed[3] == false)
            {
                TimeWarningsPlayed[3] = true;
                TimeWarnings[3].SetActive(true);
                TimeWarnings[3].GetComponent<AudioSource>().Play();
            }
        }
    }
}
