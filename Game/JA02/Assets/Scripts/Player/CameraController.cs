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
    void Start()
    {
        transform.position = mainMenuPosition;
        transform.rotation = mainMenuRotation;
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void GoToMainMenuView(){
        StartCoroutine(SmoothTransitionTo(mainMenuPosition, mainMenuRotation));
    }

    public void GoToGameView(){
        StartCoroutine(SmoothTransitionTo(inGamePosition, inGameRotation));
    }

    public void Follow(Vector3 playerPosition, float lerpTime){
        transform.position = Vector3.Lerp(transform.position, playerPosition, lerpTime);
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
