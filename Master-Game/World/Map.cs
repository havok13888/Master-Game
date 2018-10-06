using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MasterGame.World
{
    public class Map
    {
        private BaseTile [,] CurrentMap;

        public void LoadMap()
        {
            MapData loadedMap = LoadJson();
            int  rows = loadedMap.rows;
            int cols = loadedMap.cols;
            CurrentMap = new BaseTile[4, 4]
            {
                { TileFactory.CreateTile((TileType) loadedMap.tiles[0].type), TileFactory.CreateTile((TileType) loadedMap.tiles[1].type), TileFactory.CreateTile((TileType) loadedMap.tiles[2].type), TileFactory.CreateTile((TileType) loadedMap.tiles[3].type) },
                { TileFactory.CreateTile((TileType) loadedMap.tiles[4].type), TileFactory.CreateTile((TileType) loadedMap.tiles[5].type), TileFactory.CreateTile((TileType) loadedMap.tiles[6].type), TileFactory.CreateTile((TileType) loadedMap.tiles[7].type) },
                { TileFactory.CreateTile((TileType) loadedMap.tiles[8].type), TileFactory.CreateTile((TileType) loadedMap.tiles[9].type), TileFactory.CreateTile((TileType) loadedMap.tiles[10].type), TileFactory.CreateTile((TileType) loadedMap.tiles[11].type) },
                { TileFactory.CreateTile((TileType) loadedMap.tiles[12].type), TileFactory.CreateTile((TileType) loadedMap.tiles[13].type), TileFactory.CreateTile((TileType) loadedMap.tiles[14].type), TileFactory.CreateTile((TileType) loadedMap.tiles[15].type) }
            };

            MapRow testRow = new MapRow(0, 4, loadedMap);
            BaseTile testTile = testRow.GetTileRowList()[0];
        }

        public BaseTile TileAt(Point position)
        {
            //TODO: Need to do this checking in a smarter way
            if(position.X < 0 || position.Y < 0 ||
              position.X >= 4 || position.Y >= 4)
            {
                return null;
            }
            return CurrentMap[position.Y, position.X]; //X - Horizontal , Y- vertical
        }

        public void ResetTiles()
        {
            //This method should only run if the game restarts
            for(int y = 0; y < 4; y++)
            {
                for(int x = 0; x < 4; x++)
                {
                    CurrentMap[x, y].Occupied = false;
                }
            }
        }

        public MapData LoadJson()
        {
            string fileName = "Jay01.json";
            string filePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "/Assets/Maps/" + fileName;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string jsonStringData = reader.ReadToEnd();

                if (!jsonStringData.Equals(""))
                {
                    return JsonConvert.DeserializeObject<MapData>(jsonStringData);
                }
                else
                {
                    return null; //String data value cannot be empty.
                }                
            }
        }

        public class MapData
        {
            public string name { get; set; }
            public string version { get; set; }
            public int rows { get; set; }
            public int cols { get; set; }
            public Tiles [] tiles { get; set; }
            public Entities[] entities { get; set; }
        }

        public class Tiles
        {
            public int type;
            public int xCoord;
            public int yCoord;
        }

        public class Entities
        {
            public string type;
            public string name;
            public string healthPoints;
            public string xCoord;
            public string yCoord;
        }

        public class MapRow
        {
            /// <summary>
            /// This is the row number index in the map. For exmaple, if this is the 5th row, then the row num index is 4 
            /// </summary>
            private int rowNumIndex;
            /// <summary>
            /// This is number of columns in the row
            /// </summary>
            private int rowLength; 

            private List<BaseTile> tileRowList = new List<BaseTile>();

            private MapData loadedMap;

            public MapRow(int RowNumindex, int RowLength, MapData LoadedMap)
            {
                rowNumIndex = RowNumindex;
                rowLength = RowLength;
                loadedMap = LoadedMap;
                BuildTileRow();
            }

            public List<BaseTile> GetTileRowList()
            {
                return tileRowList;
            }

            /// <summary>
            /// Add the tiles to the row based on the loaded map properties.
            /// </summary>
            private void BuildTileRow()
            {
                List<Tiles> tempList = new List<Tiles>();
                foreach(Tiles tile in loadedMap.tiles) // First need to add the tiles to tile row list
                {
                    if(tile.yCoord == rowNumIndex) // Row index is the same as the y-cor. If tile does not have the same y-cor then it does not matter to this row.
                    {
                        tempList.Add(tile);
                    }
                }
                
                if (tempList.Count == rowLength) 
                {
                    //Need to make sure the tiles on in the correct order (e.g., the first tile should have x-cor =0, and then third tile should have x-cor = 2
                    bool isCorrectOrder = true;
                    for(int j =0; j < rowLength; j++)
                    {
                        
                        Tiles currentTile = loadedMap.tiles[j];
                        if(currentTile.xCoord != j)
                        {
                            //This means that the tiles are not in the correct x-cor order
                            throw new System.InvalidOperationException("Make sure the tiles are in the correct x-cor order. Take a look at the " +
                                (j + 1).ToString() +
                                " tile.");
                        }
                    }

                    for(int p = 0; p < tempList.Count; p++)
                    {
                        int tileType = tempList[p].type;
                        tileRowList.Add(TileFactory.CreateTile((TileType)tileType));
                    }
                }
                else
                {
                    throw new System.InvalidOperationException("The number of tiles in row " + 
                        rowNumIndex.ToString() + 
                        " does not equal the desiered row length, which is (" + rowLength + ")." +
                        "May need to add or remove tiles in JSON map data.");
                }
            }
        }
    }
}
