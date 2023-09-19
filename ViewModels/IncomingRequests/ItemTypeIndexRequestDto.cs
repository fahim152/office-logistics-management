using System.ComponentModel.DataAnnotations;

namespace mlbd_logistics_management.ViewModels.IncomingRequests;

public class ItemIndexTypeRequestDto
{
    [Range(1, int.MaxValue, ErrorMessage = "PageSize must be int and greater than 0")]
    public int PageSize { get; set; } = 20;

    [Range(1, int.MaxValue, ErrorMessage = "PageNumber must be int and greater than 0")]
    public int PageNumber { get; set; } = 1;

}