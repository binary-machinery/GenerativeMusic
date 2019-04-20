using UnityEngine;

public class NoteDescriptorComp : MonoBehaviour
{
    public NoteDescriptor noteDescriptor { get { return _noteDescriptor; } }

    [SerializeField]
    private NoteDescriptor _noteDescriptor;
}
