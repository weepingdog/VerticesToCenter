1 get layername function
    public static string GetLayerNameFromFeature(IFeature feature)
    return feature.Class.AliasName; //some bugs

2 public static void RemovePointMarker(IMap map)
    graphicsContainer.DeleteAllElements(); //may has bugs

3 tool undo/redo and mainframe's undo/redo

============
function to be added
1 show infomation in statusbar 
2 show snap tips
3 edit icons

