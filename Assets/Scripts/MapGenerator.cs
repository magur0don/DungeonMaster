using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	[SerializeField]
	private int width = 20;
	[SerializeField]
	private int height =20;

    void Start()
    {
        int[,] map = new int[width, height];
        // mapを埋める
        // GetUpperBound(0)は一次元配列の要素の最後の場所を返す
        // 例：[1,2,4,8,16,32]の場合、GetUpperBound(0)は5
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            // GetUpperBound(1)は二次元配列の二次元目の最後の場所を返す
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                map[x, y] = 1;
            }
        }
        // seedを決めます。Randomにしたい場合はTime.timeなどが一般的。
        float seed = 1f;
        map = RandomWalkCave(map,seed,50);
        Debug.Log(map);
    }

    /// <summary>
    // ランダムに方向を決め、位置を移動してタイルを削除すること(0にする)でdigしていきます。
    /// </summary>
    /// <param name="map">The array that holds the map information</param>
    /// <param name="seed">The seed for the random</param>
    /// <param name="requiredFloorPercent">The amount of floor we want</param>
    /// <returns>The modified map array</returns>
    public int[,] RandomWalkCave(int[,] map, float seed,  int requiredFloorPercent)
    {
        //Seed our random
        System.Random rand = new System.Random(seed.GetHashCode());

        //Define our start x position
        int floorX = rand.Next(1, map.GetUpperBound(0) - 1);
 
        //Define our start y position
        // rand.Nextは引数までの整数を返す。
        int floorY = rand.Next(1, map.GetUpperBound(1) - 1);
        //Determine our required floorAmount
        // 以下の計算は[20,20] 、requiredFloorPercentが50だと(19*19*50)/100=180マスとなる
        int reqFloorAmount = ((map.GetUpperBound(1) * map.GetUpperBound(0)) * requiredFloorPercent) / 100; 
        //Used for our while loop, when this reaches our reqFloorAmount we will stop tunneling
        int floorCount = 0;

        //Set our start position to not be a tile (0 = no tile, 1 = tile)
        map[floorX, floorY] = 0;
        //Increase our floor count
        floorCount++; 
        
        while (floorCount < reqFloorAmount)
        { 
            //Determine our next direction
            // ランダムで進む方向を決める
            int randDir = rand.Next(4); 

            switch (randDir)
            {
                case 0: //Up
                    //Ensure that the edges are still tiles
                    if ((floorY + 1) < map.GetUpperBound(1) - 1) 
                    {
                        //Move the y up one
                        floorY++;

                        //Check if that piece is currently still a tile
                        if (map[floorX, floorY] == 1) 
                        {
                            //Change it to not a tile
                            map[floorX, floorY] = 0;
                            //Increase floor count
                            floorCount++; 
                        }
                    }
                    break;
                case 1: //Down
                    //Ensure that the edges are still tiles
                    if ((floorY - 1) > 1)
                    { 
                        //Move the y down one
                        floorY--;
                        //Check if that piece is currently still a tile
                        if (map[floorX, floorY] == 1) 
                        {
                            //Change it to not a tile
                            map[floorX, floorY] = 0;
                            //Increase the floor count
                            floorCount++; 
                        }
                    }
                    break;
                case 2: //Right
                    //Ensure that the edges are still tiles
                    if ((floorX + 1) < map.GetUpperBound(0) - 1)
                    {
                        //Move the x to the right
                        floorX++;
                        //Check if that piece is currently still a tile
                        if (map[floorX, floorY] == 1) 
                        {
                            //Change it to not a tile
                            map[floorX, floorY] = 0;
                            //Increase the floor count
                            floorCount++; 
                        }
                    }
                    break;
                case 3: //Left
                    //Ensure that the edges are still tiles
                    if ((floorX - 1) > 1)
                    {
                        //Move the x to the left
                        floorX--;
                        //Check if that piece is currently still a tile
                        if (map[floorX, floorY] == 1) 
                        {
                            //Change it to not a tile
                            map[floorX, floorY] = 0;
                            //Increase the floor count
                            floorCount++; 
                        }
                    }
                    break;
            }
        }
        //Return the updated map
        return map; 
    }
}
