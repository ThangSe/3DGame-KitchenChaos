using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseCounter : MonoBehaviour, IKitChenObjectParent
{
    public static event EventHandler OnAnyObjectPlaced;

    public static void ResetStaticData()
    {
        OnAnyObjectPlaced = null;
    }

    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;
    public virtual void Interact(Player player)
    {

    }

    public virtual void InteractAlternate(Player player)
    {

    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if (kitchenObject != null)
        {
            OnAnyObjectPlaced?.Invoke(this, EventArgs.Empty);
        }
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
