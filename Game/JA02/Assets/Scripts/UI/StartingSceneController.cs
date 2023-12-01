using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartingSceneController : MonoBehaviour
{

    [SerializeField]
    private VideoPlayer startingVideo;

    [SerializeField]
    private GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        startingVideo.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){
        if(Input.GetKeyDown(KeyCode.Space)) {
            transform.gameObject.SetActive(false);
        }

    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        transform.gameObject.SetActive(false);
    }

}
