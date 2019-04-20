using UnityEngine;

public abstract class AbstractInstrument : MonoBehaviour
{
    public abstract void PlayNote(NoteDescriptor noteDescriptor, float volume);
}
