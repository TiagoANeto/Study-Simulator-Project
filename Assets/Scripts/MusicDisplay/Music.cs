using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Music : ScriptableObject
{
    public string musicName;
    private int musicIndex;
    public AudioSource audio;
}
