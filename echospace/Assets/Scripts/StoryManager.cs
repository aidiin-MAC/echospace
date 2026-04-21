using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public int chapter;
    public float timer;
    [SerializeField] float gameTimeLimit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chapter = 0;
        timer = gameTimeLimit;
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
<<<<<<< Updated upstream
=======
                timer = gameTimeLimit;
                break;
            case 1:
                canMove = true;
                for (int i = 0; i < Area1.Count; i++)
                {
                    Area1[i].SetActive(true);
                    Debug.Log("activated item " + i);
                }
                A1.TransitionTo(2f);
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
                break;
            case 7:
                NarrativeSequences[10].SetActive(true);
                NarrativeSequences[11].SetActive(true);
                NarrativeSequences[11].GetComponent<AudioSource>().Play();
                NarrativeSequences[12].SetActive(true);
                NarrativeSequences[12].GetComponent<AudioSource>().Play();
                NarrativeSequences[13].SetActive(true);
                NarrativeSequences[13].GetComponent<AudioSource>().Play();
                break;
            case 8:
                canMove = false;
                NarrativeSequences[14].SetActive(true);
                NarrativeSequences[14].GetComponent<AudioSource>().Play();
                timer = 12;
                break;
            case 9:
                canMove = false;
                chapter = 0;
                ChapterStart();
                SceneManager.LoadScene("MapTest");
>>>>>>> Stashed changes
                break;
            default:
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
