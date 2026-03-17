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
