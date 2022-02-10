using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class TimelineManager : MonoBehaviour
{
    public PlayableDirector m_playable;

    public void setTime(Vector2 value)
    {

        double maxtime = m_playable.duration;
        double actTime = value.y * maxtime;
        if (m_playable.state == PlayState.Paused)
        {
            // this will call RebuildGraph if needed
            m_playable.Play();

            // will set the speed of the graph to 0, so it's always playing but never
            // advancing
            m_playable.playableGraph.GetRootPlayable(0).SetSpeed(0);
        }

        if (actTime < 0)
            actTime = 0;
        if (actTime > maxtime)
            actTime = maxtime;
        m_playable.time = actTime;

    }

}
