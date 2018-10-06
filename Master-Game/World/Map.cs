using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MasterGame.World
{
    public class Map
    {
        private List<MapRow> CurrentMapList = new List<MapRow>();

        public void LoadMap()
        {
            MapData loadedMapData = LoadJson();
            int  rows = loadedMapData.rows;
            int cols = loadedMapData.cols;
            BuildMapList(rows, cols, loadedMapData);
        }

        public BaseTile TileAt(Point position)
        {
            //TODO: Need to do this checking in a smarter way
            if(position.X < 0 || position.Y < 0 ||
              position.X >= 4 || position.Y >= 4)
            {
                return null;
            }
            return GetTileAtLocation(position.X, position.Y);
        }

        public void ResetTiles()
        {
            //This method should only run if the game restarts
            for(int y = 0; y < 4; y++)
            {
                for(int x = 0; x < 4; x++)
                {
                    GetTileAtLocation(x, y).Occupied = false;
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
            private int colNum; 

            private List<BaseTile> tileRowList = new List<BaseTile>();

            private MapData loadedMap;

            public MapRow(int RowNumindex, int ColNum, MapData LoadedMap)
            {
                rowNumIndex = RowNumindex;
                colNum = ColNum;
                loadedMap = LoadedMap;
                BuildTileRow();
            }

            public List<BaseTile> GetTileRowList()
            {
                return tileRowList;
            }

            public BaseTile GetTileAtCor(int xCor)
            {
                return tileRowList[xCor];
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
                
                if (tempList.Count == colNum) 
                {
                    //Need to make sure the tiles on in the correct order (e.g., the first tile should have x-cor =0, and then third tile should have x-cor = 2
                    for(int j =0; j < colNum; j++)
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
                        " does not equal the desiered row length, which is (" + colNum + ")." +
                        "May need to add or remove tiles in JSON map data.");
                }
            }
        }

        private void BuildMapList(int RowNum, int ColNum, MapData LoadedMapData)
        {
            
            List <MapRow> mapList = new List<MapRow>();
            for(int i =0; i < RowNum; i++)
            {
                MapRow newMapRow = new MapRow(i, ColNum, LoadedMapData);
                mapList.Add(newMapRow);
            }
            CurrentMapList = mapList;
        }

        private BaseTile GetTileAtLocation(int xCor, int yCor)
        {
            MapRow currentRow = CurrentMapList[yCor];
            return currentRow.GetTileAtCor(xCor);            
        }
    }
}
