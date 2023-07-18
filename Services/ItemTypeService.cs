using mlbd_logistic_management.Data;

namespace mlbd_logistics_management.Services;


public class ItemTypeService
{
    private MlbdLogisticManagementContext _dbContext;

    public ItemTypeService(MlbdLogisticManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

}