using System;
using Code.Utils;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Class that provides the methods and attributes necessary to navigate circularly through a list
/// of elements
/// </summary>
/// <typeparam name="T">The type that the elements of the list will have. It is defined in the child class</typeparam>
public class CircularIndicesNavigator<T, TSelf> : Singleton<TSelf> where TSelf : MonoBehaviour
{
    #region ATTRIBUTES

    public Action<int> OnNewIndexSelected;

    /// <summary>
    /// Initialized to -1 so that the first index is not 0 by default unless we want it to be in the
    /// child class
    /// </summary>
    int _currentIndex = -1;

    public int CurrentIndex
    {
        get => _currentIndex;
        set
        {  
            if(_currentIndex != value)
            {
                _lastIndex = _currentIndex;
                _currentIndex = value;
                OnNewIndexSelected?.Invoke(_currentIndex);                
            }                        
        }
    }
       
    [SerializeField] protected List<T> _allItemsList = new();

    protected int _lastIndex = -1;

    protected int _totalItems;

    public int TotalItems
    {
        get { return _totalItems; }
        set { _totalItems = value; }
    }

    #endregion

    #region METHODS

    protected virtual void Awake()
    {
        _totalItems = _allItemsList.Count;
    }

    public virtual void AddNewItemToArray(T newItem)
    {
        _allItemsList.Add(newItem);
        _totalItems = _allItemsList.Count;
    }

    protected void GoToIndex(int newIndex)
    {
        CurrentIndex = newIndex;
    }

    protected void SwitchToPreviewIndex()
    {
        CurrentIndex = (CurrentIndex + _totalItems - 1) % _totalItems;
    }

    protected void SwitchToNextIndex()
    {
        CurrentIndex = (CurrentIndex + 1) % _totalItems;
    }

    #endregion
}
