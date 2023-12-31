using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RNGesus : MonoBehaviour
{
    public static RNGesus instance;
    public static RNGesus Get() { return instance; }
    private System.Random r;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAwake(){
        instance = this;
        r= new System.Random();
    }

    public int GetRandomIntBetween(int min, int max){
        return r.Next(min, max+1);
    }

    public T[] GetRandomSubset<T>(T[] originalArray, int x)
    {
        if (originalArray == null || x <= 0 || x > originalArray.Length)
        {
            throw new ArgumentException("Invalid input parameters");
        }

        // Shuffle the original array
        T[] shuffledArray = originalArray.OrderBy(_ => r.Next()).ToArray();

        // Take the first x elements
        T[] smallerArray = shuffledArray.Take(x).ToArray();

        return smallerArray;
    }

    public T PickOne<T>(T[] objects)
    {
        if (objects == null || objects.Length == 0)
        {
            throw new ArgumentException("The array of objects is null or empty.");
        }

        int randomIndex = r.Next(objects.Length);
        return objects[randomIndex];
    }

    public float VariedFloat(float center, float dif){
        return (float)((center-dif) + (r.NextDouble()*2*dif));
    }
}
