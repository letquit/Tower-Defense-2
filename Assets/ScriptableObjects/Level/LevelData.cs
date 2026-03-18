using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public string levelName = "Level";
    public int wavesToWins;
    public int startingReasources;
    public int startingLives;
}
