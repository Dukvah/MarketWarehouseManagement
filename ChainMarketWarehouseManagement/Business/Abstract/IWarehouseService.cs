using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IWarehouseService
    {
        IDataResult<List<Warehouse>> GetAll();
        IDataResult<Warehouse> GetById(int warehouseID);
        IResult AddWarehouse(AddWarehouseDto addWarehouseDto);
        IDataResult<List<Warehouse>> GetSubWarehouse(int warehouseID);
    }
}
