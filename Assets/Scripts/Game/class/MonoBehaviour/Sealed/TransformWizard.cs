
using UnityEngine;

public sealed class TransformWizard : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms = null;

    public Transform[] transforms { get => _transforms; }

    public static void AlignTransforms(Transform[] target, Transform[] idol)
    {
        int index_Max = target.Length;

        for (int index = 0; index < index_Max; ++index)
        {
            target[index].position = idol[index].position;

            target[index].rotation = idol[index].rotation;
        }
    }

    public static void AlignTransforms(TransformWizard target, TransformWizard idol)
    {
        AlignTransforms(target.transforms, idol.transforms);
    }
}