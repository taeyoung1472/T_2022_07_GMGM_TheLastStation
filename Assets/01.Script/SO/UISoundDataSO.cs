using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/UISoundData")]
public class UISoundDataSO : ScriptableObject
{
    public AudioClip paperOpenSound;
    public AudioClip paperCloseSound;
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip clickSound;
    public AudioClip actSound;
    public AudioClip pressButtonSound;
    public AudioClip craftSound;
    public AudioClip lightClickSound;

    public AudioClip[] footStep;
}
