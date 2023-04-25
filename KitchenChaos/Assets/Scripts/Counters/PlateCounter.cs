using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateCounter : BaseCounter
{


    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
    private float spawnPlateTimer;
    private float spwanPlateTimerMax = 4f;
    private int platesSpawnAmount;
    private int platesSpawnAmountMax = 4;
    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if(spawnPlateTimer > spwanPlateTimerMax)
        {
            spawnPlateTimer = 0f;
            if(KitchenGameManager.Instance.IsGamePlaying() &&  platesSpawnAmount < platesSpawnAmountMax)
            {
                platesSpawnAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {
            if(platesSpawnAmount > 0)
            {
                platesSpawnAmount--;
                KitchenObject.SpwanKitchenObject(plateKitchenObjectSO, player);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
