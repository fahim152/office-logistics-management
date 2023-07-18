using mlbd_logistic_management.Data;

namespace mlbd_logistics_management.Services;
public class ItemService
{
    private MlbdLogisticManagementContext _dbContext;

    public ItemService(MlbdLogisticManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

}
