using System;
using System.Collections;
using System.Collections.Generic;

// Framework for an event type.
// Methods are overloaded to ensure valid event creation
public class InfoEventArgs<T> : EventArgs
{
    public T info;

    public InfoEventArgs(){
        info = default(T);
    }

    public InfoEventArgs(T info){
        this.info = info;
    }
}
