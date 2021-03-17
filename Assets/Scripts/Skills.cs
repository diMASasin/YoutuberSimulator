using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField] private Skill _scriptWriting;
    [SerializeField] private Skill _videoEditing;
    [SerializeField] private Skill _videoRecording;
    [SerializeField] private Skill _charisma;

    public Skill ScriptWriting => _scriptWriting;
    public Skill VideoEditing => _videoEditing;
    public Skill VideoRecording => _videoRecording;
    public Skill Charisma => _charisma;

    public int CalculateSumOfSkillValues()
    {
        return _scriptWriting.Value + _videoEditing.Value + _videoRecording.Value + _charisma.Value;
    }
}
