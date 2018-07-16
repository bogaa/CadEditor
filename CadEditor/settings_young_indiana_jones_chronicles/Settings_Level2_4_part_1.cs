using CadEditor;
using System;
using System.Drawing;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec( 0xf316, 1 , 12*80, 12, 80);   }
  public bool getScreenVertical()      { return true; }
  public string getBlocksFilename()    { return "young_indiana_jones_chronicles_1_4.png"; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return false; }
  public bool isEnemyEditorEnabled()    { return false; }
}