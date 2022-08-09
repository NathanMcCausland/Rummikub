using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rummikub : MonoBehaviour
{
    public Mesh[] numberMeshes;
    public GameObject tilePrefab;

    public class RummikubGame
    {
        public List<RummikubPlayer> players = new();

        //tile groups out in the game
        public List<RummikubTileGroup> fieldTileGroups = new();

        //holds all the tiles not on the board or given to a player
        public List<RummikubTileData> tileBag = new();

        public readonly int numUniqueColors = 4;

        //how many duplicates there are of each tile (excluding jokers)
        public readonly int numColorValueDuplicates = 2;

        public readonly int numJokers = 2;
     
        public RummikubGame(int num_players)
        {
            GenerateTileSet();

            for(int i = 0; i < num_players; i++)
            {
                AddPlayer();
            }
        }

        void AddPlayer()
        {
            RummikubPlayer player = new RummikubPlayer();

            for(int i = 0; i < RummikubPlayer.STARTING_NUM_TILES; i++)
            {
                player.tilesInHand.Add(GetRandomBagTile());
            }
        }

        RummikubTileData GetRandomBagTile()
        {
            if(tileBag.Count == 0)
            {
                Debug.Log("Cannot draw new tile, there are no more in the bag!");
                return null;
            }

            //grab random tile
            int tile_index = Random.Range(0, tileBag.Count);
            RummikubTileData result = tileBag[tile_index];

            //remove from bag
            tileBag.Remove(result);

            return result;
        }

        void GenerateTileSet()
        {
            //for each unique color generate a set of tiles for it
            for(int color_index = 0; color_index < numUniqueColors; color_index++)
            {
                for(int value = 1; value <= 12; value++)
                {
                    for (int i = 0; i < numColorValueDuplicates; i++)
                    {
                        tileBag.Add(new RummikubTileData(color_index, value));
                    }
                }
            }

            //add jokers
            for(int i = 0; i < numJokers; i++)
            {
                //TODO: maybe alternate joker colors?
                tileBag.Add(new RummikubTileData(0, RummikubTileData.JOKER_VALUE));
            }
        }
    }

    public class RummikubPlayer
    {
        public const int STARTING_NUM_TILES = 14;

        public List<RummikubTileData> tilesInHand = new();
    }

    public class RummikubTileGroup
    {
        public List<RummikubTile> tiles = new();
    }

    public class RummikubTileData
    {
        public const int JOKER_VALUE = -1;

        public readonly int value;
        public readonly int color;

        public RummikubTileData(int color, int value)
        {
            this.value = value;
            this.color = color;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
