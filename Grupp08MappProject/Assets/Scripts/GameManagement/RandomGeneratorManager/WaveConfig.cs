using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = " \"Waves\"-Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private float minRandomTime;
    [SerializeField] private float maxRandomTime;
    [SerializeField] private List<ObjectPool> listOfPools;
    [SerializeField] private bool hasNewPools;

    public float MinRandomTime { get => minRandomTime; }
    public float MaxRandomTime { get => maxRandomTime; }
    public List<ObjectPool> ListOfPools { get => listOfPools; }
    public bool HasNewPools { get => hasNewPools; }


    [System.Serializable]
    public class ObjectPool
    {
        public bool hasParameterChanges;
        public string tag;
        public GameObject prefab;
        public int size;
        public float scrollSpeedMultiplier = 1f;
    }
}
