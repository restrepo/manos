﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manos
{
    public abstract class BaseWatcher: IBaseWatcher, IDisposable
    {
        public BaseWatcher(Loop loop)
        {
            this.Loop = loop;
        }
        protected bool running;
		
        public bool IsRunning
        {
            get { return running; }
        }

        public Loop Loop
        {
            get;
            private set;
        }

        public object UserData
        {
            get;
            set;
        }

        public virtual void Dispose () { }

        public abstract void Start ();
        public abstract void Stop ();

    }

    public interface IBaseWatcher: IDisposable
    {
        void Start ();
        void Stop ();
        object UserData
        {
            get;
            set;
        }
        Loop Loop
        {
            get;
        }
        bool IsRunning
        {
            get;
        }
    }

    public interface IAsyncWatcher: IBaseWatcher  // always a base watcher
    {
        void Send ();
    }
}
