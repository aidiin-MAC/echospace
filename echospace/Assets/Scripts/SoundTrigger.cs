using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource target;
    private GameObject Manager;
    private StoryManager Story;
    [SerializeField] string type;
    [SerializeField] string effectName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (type == "story" || type == "effect")
        {
            Manager = GameObject.FindGameObjectWithTag("Manager");
            Story = Manager.GetComponent<StoryManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (type)
            {
                case "Story":
                    Debug.Log("TheStoryIsProgressing");
                    Story.IncrementChapter();
                    gameObject.SetActive(false);
                    break;
                case "OneTime":
                    target.Play();
                    Debug.Log("this would play a scary sound");
                    gameObject.SetActive(false);
                    break;
                case "Repeatable":
                    target.Play();
                    Debug.Log("this would play a scary sound");
                    break;
                case "Effect":
                    Story.EffectToggle(effectName);
                    break;
            }
        }
    }
}
