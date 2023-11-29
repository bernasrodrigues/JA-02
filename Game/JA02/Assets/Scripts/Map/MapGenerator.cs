using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private int noiseIterationMultiplier;
    [SerializeField]
    private int levelMultiplier;
    [SerializeField]
    private int tileSize;
    [SerializeField]
    private GameObject interiorTileObj;

    [SerializeField]
    private GameObject exteriorTileObj;

    [SerializeField]
    private Tuple<int,int>[] mapPositions;

    private GameObject newGO;

    public Tuple<int,int>[] MapPositions { get => mapPositions; set => this.mapPositions = value; }
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnAwake(){   
    }

    public void  Initialize(int level){
        
        int highestLimit = levelMultiplier * level;
        int lowestLimit = -highestLimit;
        
        Tuple<int,int>[] startingSquareSpots = StartingSquareInit(lowestLimit, highestLimit);
        Tuple<int,int>[] chipSpots = InitializeChipSpots(highestLimit);
        Tuple<int, int>[] connectionSpots = ConnectMap(startingSquareSpots, chipSpots);
        Tuple<int, int>[] noiseSpots = MakeNoisePositions(startingSquareSpots.Concat(chipSpots).Concat(connectionSpots).ToArray(), level);

        mapPositions = startingSquareSpots.Concat(chipSpots).Concat(connectionSpots).Concat(noiseSpots).ToArray();
        MapSys.instance.SetMap(mapPositions);
        MakeOutlineTiles(CalculateOutlineTiles(mapPositions));
    }

    public Tuple<int,int>[] StartingSquareInit(int lowestLimit, int highestLimit){
        
        int rowSize = 1+(highestLimit-lowestLimit);
        Tuple<int,int>[] spots = new Tuple<int, int>[rowSize*rowSize];   
        
        int counter = 0;
        
        for(int x = lowestLimit; x <= highestLimit; x++){
            for(int y = lowestLimit; y <= highestLimit; y++){
                
                InstantiateInteriorTileAt(x,y);
                spots[counter] = new Tuple<int, int>(x,y);
                counter++;
            }
        }

        return spots;
    }

    public Tuple<int,int>[] InitializeChipSpots(int highestLimit){
        
        Tuple<int,int>[] spots = new Tuple<int, int>[4]; 
        
        int randomCordX = RNGesus.instance.GetRandomIntBetween(highestLimit+levelMultiplier, (levelMultiplier*highestLimit)+levelMultiplier);
        int randomCordY = RNGesus.instance.GetRandomIntBetween(highestLimit+levelMultiplier, (levelMultiplier*highestLimit)+levelMultiplier);
        
        spots[0] = new Tuple<int, int>(randomCordX, randomCordY);
        spots[1] = new Tuple<int, int>(randomCordX, -randomCordY);
        spots[2] = new Tuple<int, int>(-randomCordX, randomCordY);
        spots[3] = new Tuple<int, int>(-randomCordX, -randomCordY);

        Tuple<int,int>[] chipAndChipKeySpots = RNGesus.instance.GetRandomSubset(spots, 2);
        MapSys.instance.SetChipSpot(chipAndChipKeySpots[0]);
        MapSys.instance.SetChipKeySpot(chipAndChipKeySpots[1]);

        foreach(Tuple<int,int> spot in spots){
            InstantiateInteriorTileAt(spot.Item1, spot.Item2);
        }

        return spots;
    }

    public Tuple<int,int>[] ConnectMap(Tuple<int,int>[] startingSpots, Tuple<int,int>[] chipSpots){
        
        List<Tuple<int,int>> connectionSpotsList = new List<Tuple<int, int>>(); 

        foreach(Tuple<int,int> spot in chipSpots){
           connectionSpotsList.AddRange(FindPathToSquare(spot, startingSpots));
        }


        return connectionSpotsList.ToArray();
    }

    public List<Tuple<int,int>> FindPathToSquare(Tuple<int,int> spot, Tuple<int,int>[] startingSpots){
        
        List<Tuple<int,int>> positionList = new List<Tuple<int,int>>();
        Tuple<int,int> currentSpot = spot;

        while(!(startingSpots.Any(t => t.Equals(currentSpot)))){
            if(Math.Abs(currentSpot.Item1) > Math.Abs(currentSpot.Item2)){
                currentSpot = new Tuple<int,int>(currentSpot.Item1- (currentSpot.Item1/Math.Abs(currentSpot.Item1)), currentSpot.Item2);
            }
            else{
                currentSpot = new Tuple<int,int>(currentSpot.Item1, currentSpot.Item2- (currentSpot.Item2/Math.Abs(currentSpot.Item2)));
            }
            InstantiateInteriorTileAt(currentSpot.Item1, currentSpot.Item2);
            positionList.Add(currentSpot);
        }
        Destroy(newGO);
        positionList.Remove(currentSpot);

        return positionList;
    }

    public Tuple<int,int>[] CalculateOutlineTiles(Tuple<int, int>[] positions){
        HashSet<Tuple<int, int>> uniqueOutlinePositions = new HashSet<Tuple<int, int>>();

        // Add original positions to the HashSet to exclude them from the outline
        uniqueOutlinePositions.UnionWith(positions);

        foreach (var position in positions)
        {
            int x = position.Item1;
            int y = position.Item2;

            // Add outline positions
            for (int xOffset = -1; xOffset <= 1; xOffset++)
            {
                for (int yOffset = -1; yOffset <= 1; yOffset++)
                {
                    if (xOffset != 0 || yOffset != 0)
                    {
                        var outlinePosition = Tuple.Create(x + xOffset, y + yOffset);

                        // Add to the HashSet to ensure uniqueness
                        uniqueOutlinePositions.Add(outlinePosition);
                    }
                }
            }
        }

        uniqueOutlinePositions.ExceptWith(positions);
        // Remove original positions from the HashSet to exclude them from the outline
        return uniqueOutlinePositions.ToArray();
    }

    public Tuple<int, int>[] CalculateOutlineTilesWithoutDiagonals(Tuple<int, int>[] positions)
    {
        HashSet<Tuple<int, int>> uniqueOutlinePositions = new HashSet<Tuple<int, int>>();

        foreach (var position in positions)
        {
            int x = position.Item1;
            int y = position.Item2;

            // Add outline positions (excluding diagonals)
            var outlineOffsets = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

            foreach (var offset in outlineOffsets)
            {
                var outlinePosition = Tuple.Create(x + offset.Item1, y + offset.Item2);

                // Add to the HashSet to ensure uniqueness
                uniqueOutlinePositions.Add(outlinePosition);
            }
        }

        // Remove original positions from the HashSet to exclude them from the outline
        uniqueOutlinePositions.ExceptWith(positions);

        return uniqueOutlinePositions.ToArray();
    }


    public Tuple<int,int>[] MakeNoisePositions(Tuple<int,int>[] positions, int level){
        Tuple<int,int>[] currentPositions;
        Tuple<int,int>[] currentOutline;
        Tuple<int,int>[] outlineToInstanceSubset;
        List<Tuple<int,int>> addedPositions = new List<Tuple<int, int>>();
        for(int i = 0; i<level*noiseIterationMultiplier; i++){
            currentPositions = positions.Concat(addedPositions.ToArray()).ToArray();
            currentOutline = CalculateOutlineTilesWithoutDiagonals(currentPositions);
            outlineToInstanceSubset = RNGesus.instance.GetRandomSubset(currentOutline, level*noiseIterationMultiplier);
            foreach(Tuple<int,int> position in outlineToInstanceSubset){
                InstantiateInteriorTileAt(position.Item1, position.Item2);
                addedPositions.Add(position);
            }
            
        }
        return addedPositions.ToArray();
    }
    public void MakeOutlineTiles(Tuple<int, int>[] outlinePositions)
    {
        foreach(Tuple<int,int> position in outlinePositions){
            InstantiateExteriorTileAt(position.Item1, position.Item2);
        }
    }

    public void InstantiateInteriorTileAt(int xCoordinate, int yCoordinate){
        newGO = Instantiate(interiorTileObj, transform);
        newGO.transform.position = new Vector3(xCoordinate*tileSize, 0, yCoordinate*tileSize);
    }
    public void InstantiateExteriorTileAt(int xCoordinate, int yCoordinate){
        newGO = Instantiate(exteriorTileObj, transform);
        newGO.transform.position = new Vector3(xCoordinate*tileSize, 0, yCoordinate*tileSize);
    }
}
