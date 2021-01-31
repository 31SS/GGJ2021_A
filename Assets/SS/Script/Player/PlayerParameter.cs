using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameter", menuName = "PlayerParameter")]
public class PlayerParameter : ScriptableObject
{
    public float LOWRUN_SPEED;
    public float RUN_SPEED;
    public float HIGHRUN_SPEED;
    public float LOWJUMP_POWER;
    public float JUMP_POWER;
    public float HIGHJUMP_POWER;
}