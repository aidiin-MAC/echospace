using UnityEngine;

public class ReverbTrigger : MonoBehaviour
{
    public AudioReverbFilter reverb;
    public GameObject mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        reverb = mainCamera.GetComponent<AudioReverbFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            reverb.enabled = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            reverb.enabled = false;
        }
    }
}
