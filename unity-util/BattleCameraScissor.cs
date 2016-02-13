//
// BattleCameraScissor.cs
//
// Copyright 2016 MunkyFun. All rights reserved.
//

#region Using Statements

// UnityEngine
using UnityEngine;

// C# libs
using System;

// Internal
using Core.Diagnostics;

#endregion // Using Statements

public class BattleCameraScissor : MonoBehaviour
{
    public RectTransform BottomClippingLocator;
    private Camera Cam;

    void Awake()
    {
        Cam = GetComponent<Camera>();
        if(!Cam)
        {
            Assert.Never("BattleCameraScissor should only be attached to camera");
            Destroy(this);
        }
        if(!BottomClippingLocator || BottomClippingLocator.pivot.y != 1f)
        {
            Assert.Never("BottomClippingLocator pivot.y has to be set to 1");
            Destroy(this);
        }

    }

    // http://forum.unity3d.com/threads/scissor-rectangle.37612/
    void OnPreCull()
    {
        if (!Cam || !Battle.Inst)
            return;

        // BottomClippingLocator is anchored to the bottom center
        float y = BottomClippingLocator.anchoredPosition.y / ((RectTransform)Battle.Inst._BattleUI.transform).rect.height;
        var newRect = new Rect(0, y, 1, 1 - y);

        newRect.x = Mathf.Clamp(newRect.x, 0f, 1f);
        newRect.y = Mathf.Clamp(newRect.y, 0f, 1f);
        newRect.width = Mathf.Clamp(newRect.width, 0f, 1 - newRect.x);
        newRect.height = Mathf.Clamp(newRect.height, 0f, 1 - newRect.y);

        Cam.rect = new Rect(0, 0, 1, 1);
        Cam.ResetProjectionMatrix();
        Matrix4x4 m1 = Cam.projectionMatrix;
        Cam.rect = newRect;
        Matrix4x4 m2 = Matrix4x4.TRS(new Vector3((1 / newRect.width - 1), (1 / newRect.height - 1), 0), Quaternion.identity, new Vector3(1 / newRect.width, 1 / newRect.height, 1));
        Matrix4x4 m3 = Matrix4x4.TRS(new Vector3(-newRect.x * 2 / newRect.width, -newRect.y * 2 / newRect.height, 0), Quaternion.identity, Vector3.one);
        Cam.projectionMatrix = m3 * m2 * m1;
    }
}
