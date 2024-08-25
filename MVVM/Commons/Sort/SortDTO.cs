public class SortDTO
{
    public SortColumn SortColumn { get; set; }
    public SortDirection SortDirection { get; set; }

    public SortDTO(SortDirection direction, SortColumn column)
    {
        SortColumn = column;
        SortDirection = direction;
    }
}

