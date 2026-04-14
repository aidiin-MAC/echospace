using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource target;
    private GameObject Manager;
    private StoryManager Story;
    public string type;
    private bool active;
    [SerializeField] string effectName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (type == "Story" || type == "Effect" || type == "Footstep")
        {
            Manager = GameObject.FindGameObjectWithTag("Manager");
            Story = Manager.GetComponent<StoryManager>();
        }
        active = true;
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
                    if (active)
                    {
                        target.Play();
                        Debug.Log("this would play a scary sound");
                        active = false;
                    }
                    break;
                case "Repeatable":
                    target.Play();
                    Debug.Log("this would play a scary sound");
                    break;
                case "Effect":
                    Story.EffectToggle(effectName);
                    Debug.Log("FootstepChanged");
                    break;
                case "Footstep":
                    Story.EffectToggle(effectName);
                    break;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("isPlayer");
            if (type == "Footstep")
            {
                Story.EffectToggle("footstep0");
            }
        }
    }
}
