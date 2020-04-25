using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                throw new Exception("Singleton does not exist.");
            }

            return _instance;
        }
        protected set => _instance = value;
    }
}
