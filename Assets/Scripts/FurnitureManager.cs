using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class FurnitureManager : MonoBehaviour
{

    public ARPlacementInteractable ARPlacementInteractable;
    public GameObject couch1;
    public GameObject couch2;
    public GameObject couch3;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void chooseCouch1()
    {
        ARPlacementInteractable.placementPrefab = couch1;

    }

    public void chooseCouch2()
    {
        ARPlacementInteractable.placementPrefab = couch2;


    }
    public void chooseCouch3()
    {
        ARPlacementInteractable.placementPrefab = couch3;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
