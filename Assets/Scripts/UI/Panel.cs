// Following Script Taken from `The Liquid Fire`'s Unity TBSRPG guide
// Allows for easier positioning of canvas elements



/* Taken from an open source git repo in accordance with the liscense*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof(LayoutAnchor))]
public class Panel : MonoBehaviour
{
    [Serializable]
    public class Position
    {
        public string name;
        public TextAnchor myAnchor;
        public TextAnchor parentAnchor;
        public Vector2 offset;

        public Position(string name)
        {
            this.name = name;
        }

        public Position(string name, TextAnchor myAnchor, TextAnchor parentAnchor) : this(name)
        {
            this.myAnchor = myAnchor;
            this.parentAnchor = parentAnchor;
        }

        public Position(string name, TextAnchor myAnchor, TextAnchor parentAnchor, Vector2 offset) : this(name, myAnchor, parentAnchor)
        {
            this.offset = offset;
        }
    }

    [SerializeField] List<Position> positionList;
    Dictionary<string, Position> positionMap;
    LayoutAnchor anchor;

    public Position CurrentPosition { get; private set; }

    public Position this[string name]
    {
        get
        {
            if (positionMap.ContainsKey(name))
                return positionMap[name];
            return null;
        }
    }

    void Awake(){
        anchor = GetComponent<LayoutAnchor>();
        positionMap = new Dictionary<string, Position>(positionList.Count);
        for(int i = positionList.Count - 1; i >= 0; --i) 
            AddPosition(positionList[i]);
    }

    public void AddPosition( Position p){
        positionMap[p.name] = p;
    }

    public void RemovePosition (Position p){
        if(positionMap.ContainsKey(p.name))
            positionMap.Remove(p.name);
    }


    public void SetPosition(Position p){
        CurrentPosition = p;
        if (CurrentPosition == null) return;
        anchor.SnapToAnchorPosition(p.myAnchor, p.parentAnchor, p.offset);
    }

    public void SetPosition(string positionName){
        SetPosition(this[positionName]);
    }

    void Start()
    {
        if (CurrentPosition == null && positionList.Count > 0)
            SetPosition(positionList[0]);
    }

}
