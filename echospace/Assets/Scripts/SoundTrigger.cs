using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource target;
    [SerializeField] bool isStoryTrigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isStoryTrigger == true)
        {
            GameObject Manager = GameObject.FindGameObjectWithTag("Manager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isStoryTrigger == true)
        {
            Debug.Log("TheStoryIsProgressing");
        }
        else
        {
            target.Play();
            Debug.Log("this would play a scary sound");
        }

    }
}
