﻿/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCompress.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/5/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Work.Compress.Demo
{
    public abstract class MonoCompress : MonoBehaviour
    {
        protected ICompressHub hub;
        protected IAsyncWorkHandler<string> handler;

        void Awake()
        {
            hub = CompressHubFactory.CreateHub();
        }

        void OnDestroy()
        {
            hub.Dispose();
            hub = null;

            if (handler != null)
            {
                handler.Dispose();
                handler = null;
            }
        }
    }
}