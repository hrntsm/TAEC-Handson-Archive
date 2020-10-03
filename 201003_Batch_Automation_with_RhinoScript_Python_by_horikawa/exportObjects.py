import rhinoscriptsyntax as rs
import createBox


def Run(objs, dir, ext):
    
    rs.EnableRedraw(False)
    for i in range(len(objs)):
        obj = objs[i]
        filepath = dir + "\exported" + str(i) + "." + ext

        rs.SelectObject(obj)
        rs.Command("!_-Export \"" + filepath + "\" -Enter -Enter")
        rs.UnselectAllObjects()
    rs.EnableRedraw(True)    


boxes = createBox.Run(4, 4)
dir = "D:\Repos\TAEC-handson\\201003_Batch_Automation_with_RhinoScript_Python_by_horikawa"

Run(boxes, dir, "3dm")    
