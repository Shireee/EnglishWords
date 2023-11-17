using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(fileName = "GameData", menuName = "Game Data", order = 51)]
public class DataScript : ScriptableObject
{
    [SerializeField] int level;
    [SerializeField] List<string> data;
    [SerializeField] List<string> topics;

    // Load .txt data from Resources 
    void Awake()
    {
        data = new List<string>(Resources.LoadAll<TextAsset>("Data")
        .Select(e => e.name));
        SetLevel(level);
    }
    public int Level { get => level; }
    public void SetLevel(int newLevel)
    {
        level = newLevel;
        topics = new List<string>(data
        .Where(e => e.StartsWith((newLevel + 1) + ".")));
    }
    public int TopicCount { get => topics.Count; }
    public string Topic(int i) => topics[i].Remove(0, 2);

    void Reset() => Awake();
}
