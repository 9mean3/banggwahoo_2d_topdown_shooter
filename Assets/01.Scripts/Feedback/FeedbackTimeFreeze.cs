using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class FeedbackTimeFreeze : Feedback
{
    [SerializeField]
    private float _freezeTimeDelay = 0.05f, _unFreezeTimeDelay = 0.02f;
    [SerializeField]
    [Range(0, 1f)]
    private float _timeFreezeValue;

    public override void CompleteFeedback()
    {
        TimeController.Instance?.ResetTimeScale();
    }

    public override void CreateFeedback()
    {
        TimeController.Instance?.ModifyTimeScale(_timeFreezeValue, _freezeTimeDelay, () =>
        {
            TimeController.Instance?.ModifyTimeScale(1, _unFreezeTimeDelay);
        });

    }
}
