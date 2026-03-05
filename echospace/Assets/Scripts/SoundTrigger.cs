using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        target.Play();
        Debug.Log("this would play a scary sound");
    }
}
