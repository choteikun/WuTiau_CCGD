using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public GameObject gameBGM;
    GameObject BGM = null;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.FindGameObjectWithTag("Bgm");
        if (BGM == null)
        {
            BGM = Instantiate(gameBGM);
            
        }
        audioSource = BGM.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = AudioSourceController.volumeAllScale / 10;
    }
}
