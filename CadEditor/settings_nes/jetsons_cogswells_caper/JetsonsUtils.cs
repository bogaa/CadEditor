using CadEditor;
using System;

public static class JetsonsUtils 
{ 
  public static BigBlock[] getBigBlocksTT(int bigTileIndex)
  {
    var data = Utils.readLinearBigBlockData(0, bigTileIndex, 4);
    var bb = Utils.unlinearizeBigBlocks<BigBlockWithPal>(data, 2, 2);
    for (int i = 0; i < bb.Length; i++)
    {
      int palByte = getTTSmallBlocksColorByte(i);
      bb[i].palBytes[0] = palByte >> 0 & 0x3;
      bb[i].palBytes[1] = palByte >> 2 & 0x3;
      bb[i].palBytes[2] = palByte >> 4 & 0x3;
      bb[i].palBytes[3] = palByte >> 6 & 0x3;
    }
    return bb;
  }
  
  public static void setBigBlocksTT(int bigTileIndex, BigBlock[] bigBlockIndexes)
  {
      var bigBlocksAddr = ConfigScript.getBigTilesAddr(0, bigTileIndex); 
      for (int v = 0; v < bigBlockIndexes.Length; v++)
      {
          var bb = bigBlockIndexes[v] as BigBlockWithPal;
          var i0 = bb.indexes[0];
          var i1 = bb.indexes[1];
          var i2 = bb.indexes[2];
          var i3 = bb.indexes[3];
          Globals.romdata[bigBlocksAddr + v * 4 + 0] = (byte)i0;
          Globals.romdata[bigBlocksAddr + v * 4 + 1] = (byte)i2;
          Globals.romdata[bigBlocksAddr + v * 4 + 2] = (byte)i1;
          Globals.romdata[bigBlocksAddr + v * 4 + 3] = (byte)i3;
          
          int palByte = bb.palBytes[0] | bb.palBytes[1] << 2 | bb.palBytes[2]<<4 | bb.palBytes[3]<< 6;
          setTTSmallBlocksColorByte(v, (byte)palByte);
      }
  }
  
  private static byte getTTSmallBlocksColorByte(int index)
  {
    return Globals.romdata[ConfigScript.getPalBytesAddr(0)+index];
  }
  
  private static void setTTSmallBlocksColorByte(int index, byte colorByte)
  {
    Globals.romdata[ConfigScript.getPalBytesAddr(0)+index] = colorByte;
  }
}