namespace OCCTProxy.Common.Interfaces
{
    public interface IManagedObjHandle
    {
        int AisShapeBindId { get; set; }
        int BindId { get; set; }
        int ShapeType { get; set; }        
    }
}
