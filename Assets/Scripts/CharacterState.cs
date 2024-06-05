using UnityEngine;
using System.Collections.Generic;

public class CharacterState
{
    public Vector3 Position { get; private set; }
    public Quaternion Rotation { get; private set; }
    public Dictionary<string, float> AnimationParameters { get; private set; }

    public CharacterState(Vector3 position, Quaternion rotation, Dictionary<string, float> animationParameters)
    {
        Position = position;
        Rotation = rotation;
        AnimationParameters = animationParameters;
    }
}