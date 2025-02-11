using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class WarehouseManager : IWarehouseService
    {
        private readonly IWarehouseDal _warehouseDal;
        public WarehouseManager(IWarehouseDal warehouseDal)
        {
            _warehouseDal = warehouseDal;
        }

        public IResult AddWarehouse(AddWarehouseDto addWarehouseDto)
        {
            var newWarehouse = new Warehouse();
            newWarehouse.Name = addWarehouseDto.Name;
            newWarehouse.Address = addWarehouseDto.Address;
            newWarehouse.MainWarehouseID = addWarehouseDto.MainWarehouseID;
            _warehouseDal.Add(newWarehouse);
            return new SuccessDataResult<AddWarehouseDto>(addWarehouseDto, Messages.WarehouseAdded);
        }

        public IDataResult<List<Warehouse>> GetAll()
        {
            return new SuccessDataResult<List<Warehouse>>(_warehouseDal.GetAll(), Messages.WarehousesListed);
        }

        public IDataResult<Warehouse> GetById(int warehouseID)
        {
            return new SuccessDataResult<Warehouse>(_warehouseDal.Get(p => p.Id == warehouseID));
        }

        public IDataResult<List<Warehouse>> GetSubWarehouse(int warehouseID)
        {
            var subWarehouses = new List<Warehouse>();
            var warehouses = GetAll().Data;
            foreach (var item in warehouses)
            {
                if (item.MainWarehouseID == warehouseID)
                {
                    subWarehouses.Add(item);
                }
            }

            return new SuccessDataResult<List<Warehouse>>(subWarehouses, Messages.SubwarehousesListed);
        }
    }
}
