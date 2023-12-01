using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3 mainMenuPosition;
    [SerializeField]
    private Quaternion mainMenuRotation;
    [SerializeField]
    private Vector3 inGamePosition;
    [SerializeField]
    private Quaternion inGameRotation;
    [SerializeField]
    private float transitionDuration = 2.0f;
    [SerializeField]
    private float cameraHeight;
    [SerializeField]
    private float maxCamHeight;
    [SerializeField]
    private float minCamHeight;
    [SerializeField]
    private float camZoomFactor;
    [SerializeField]
    private GameObject playerSpawnerArea;

    private float mouseScrollDeltaAvg;


    private Vector3 cameraOffset;

    void Start()
    {
        transform.position = mainMenuPosition;
        transform.rotation = mainMenuRotation;
        mouseScrollDeltaAvg = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mouseScrollDeltaAvg += Input.mouseScrollDelta.y;
    }

    void FixedUpdate(){

        // Check if left Shift is being pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            cameraHeight+=camZoomFactor;
        }

        // Check if left Control is being pressed
        if (Input.GetKey(KeyCode.LeftControl))
        {
            cameraHeight-=camZoomFactor;
        }

        cameraHeight -= mouseScrollDeltaAvg * camZoomFactor * 1.5f;
        mouseScrollDeltaAvg = 0;

        // sim, dava para fazer os dois no mesmo mas n�o me apetece :P
        cameraHeight = Mathf.Max(minCamHeight, cameraHeight);
        cameraHeight = Mathf.Min(maxCamHeight, cameraHeight);
        float scale = cameraHeight * 3.5f;
        playerSpawnerArea.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void GoToMainMenuView(){
        StartCoroutine(SmoothTransitionTo(mainMenuPosition, mainMenuRotation));
    }

    public void GoToGameView(){
        StartCoroutine(SmoothTransitionTo(inGamePosition, inGameRotation));
    }

    public void Follow(Vector3 playerPosition, float lerpTime){
        cameraOffset = new Vector3(0, cameraHeight, 0);
        transform.position = Vector3.Lerp(transform.position, playerPosition+cameraOffset, lerpTime);
    }

    private IEnumerator SmoothTransitionTo(Vector3 targetPos, Quaternion targetRot)
    {
        // Smoothly transition to the target position and rotation
        float elapsed = 0f;
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        while (elapsed < transitionDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / transitionDuration);
            transform.rotation = Quaternion.Slerp(startRot, targetRot, elapsed / transitionDuration);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Wait for a moment (you can adjust this duration)
        yield return new WaitForSeconds(1.0f);
    }
}
