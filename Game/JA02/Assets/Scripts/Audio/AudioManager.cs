using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private long counter = 0;

    [SerializeField]
    private Dictionary<long, Coroutine> activeCoroutines = new Dictionary<long, Coroutine>();

    [SerializeField]
    GameObject newGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(AudioClip clip, float volume, float pitch, int priority, int stereoPan, float spatialBlend, float reverbZoneMix){

        Coroutine coroutine = StartCoroutine(PlaySoundInstanceEnum(clip, counter, volume, pitch, priority, stereoPan, spatialBlend, reverbZoneMix)); 
        activeCoroutines.Add(counter, coroutine);
        counter++;
    }

    public void RemoveCoroutine(long coroutineId, GameObject go){
        if (activeCoroutines.TryGetValue(coroutineId, out Coroutine coroutine))
        {
            StopCoroutine(coroutine);
            activeCoroutines.Remove(coroutineId);
        }
        DestroyImmediate(go);
    }

    IEnumerator PlaySoundInstanceEnum(AudioClip aud, long coroutineId, float volume, float pitch, int priority, int stereoPan, float spatialBlend, float reverbZoneMix){
        newGO = new GameObject();
        newGO.transform.parent = this.transform;
        newGO.AddComponent<AudioSource>();
        newGO.GetComponent<AudioSource>().playOnAwake = false;
        newGO.GetComponent<AudioSource>().clip = aud;


        newGO.GetComponent<AudioSource>().volume = volume;
        newGO.GetComponent<AudioSource>().pitch = pitch;
        newGO.GetComponent<AudioSource>().priority = priority;
        newGO.GetComponent<AudioSource>().panStereo = stereoPan;
        newGO.GetComponent<AudioSource>().spatialBlend = spatialBlend;
        newGO.GetComponent<AudioSource>().reverbZoneMix = reverbZoneMix;


        newGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(aud.length);
        RemoveCoroutine(coroutineId, newGO);
    }
    
}
