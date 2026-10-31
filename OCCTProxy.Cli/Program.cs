using OCCTProxy.Common;
using OCCTProxy.Common.Interfaces;


IOCCTProxyInterface proxy = new OCCTProxy.OCCTProxy();

proxy.runHeadless();


proxy.ActivateGrid(true);
//proxy.ShowCube();
proxy.SetDisplayMode(1);
proxy.SetMaterial(1);
//proxy.SetDegenerateModeOff();
proxy.RedrawView();


var cs = proxy.MakeBox(0, 0, 0, 10, 20, 30);


proxy.UpdateCurrentViewer();
proxy.UpdateView();

var top = new TopObjHandle() { BindId = cs.BindId };
var poly = proxy.IteratePoly(top);

string obj = BREPUtils.ExtractObj(proxy, top, true, true);
var path = "cube.obj";

File.WriteAllText(path, obj);
Console.WriteLine($"saved to {path} successfully");
