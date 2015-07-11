using CadEditor;
using System;
using System.Collections.Generic;
//css_include Settings_CHC-Utils.cs;

public class Data 
{ 
  public string[] getPluginNames() 
  {
    return new string[] 
    {
      "PluginSegaBackEditor.dll",
    };
  }
  public bool isUseSegaGraphics()      { return true; }
  public bool isBlockSize4x4()         { return true; }
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x0, 1 , 128*32);   }
  public int getScreenWidth()          { return 128; }
  public int getScreenHeight()         { return 32;  }
  
  public GetVideoChunkFunc    getVideoChunkFunc()    { return getVideoChuck;}
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public GetBigBlocksFunc     getBigBlocksFunc()     { return getBigBlocks; }
  public SetBigBlocksFunc     setBigBlocksFunc()     { return setBigBlocks; }
  
  public GetPalFunc           getPalFunc()           { return readPal;}
  public SetPalFunc           setPalFunc()           { return null;}
  
  public LoadSegaBackFunc     loadSegaBackFunc()     { return loadBack;}
  public SaveSegaBackFunc     saveSegaBackFunc()     { return saveBack;}
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return true; }
  public bool isEnemyEditorEnabled()    { return true; }
  
  public GetObjectsFunc getObjectsFunc() { return CHCUtils.getObjects; }
  public GetObjectDictionaryFunc getObjectDictionaryFunc() { return CHCUtils.getObjectDictionary; }
  public SetObjectsFunc setObjectsFunc() { return null; }
  public IList<LevelRec> getLevelRecs()  { return levelRecs;  }
  public GetLayoutFunc getLayoutFunc()   { return getLayout;  }
  
  public int getMaxObjType()             { return 0x500; }
  
  public IList<LevelRec> levelRecs = new List<LevelRec>() 
  {
    new LevelRec(0x7E88E, 26, 1, 1, 0), 
  };
  
  private string VIDEO_NAME  = "vram_22.bin";
  private string BLOCKS_NAME = "blocks_22.bin"; //1E8740//1EA6A6
  private string PAL_NAME    = "pal_22.bin";
  private string BACK_NAME    = "back_22.bin";
  
  LevelLayerData getLayout(int levelNo)
  {
    byte[] layer = new byte[1];
    layer[0] = 1;
    return new LevelLayerData(1, 1, layer);
  }
  
  public byte[] getVideoChuck(int videoPageId)
  {
    return Utils.readBinFile(VIDEO_NAME);
  }

  public byte[] getBigBlocks(int bigTileIndex)
  {
    return Utils.readBinFile(BLOCKS_NAME);
  }
  
  public void setBigBlocks(int bigTileIndex, byte[] data)
  {
    Utils.saveDataToFile(BLOCKS_NAME, data);
  }
  
  public byte[] readPal(int palNo)
  {
    return Utils.readBinFile(PAL_NAME);
  }
  
  public byte[] loadBack()
  {
    return Utils.loadDataFromFile(BACK_NAME);
  }
  
  public void saveBack(byte[] data)
  {
    Utils.saveDataToFile(BACK_NAME, data);
  }
}