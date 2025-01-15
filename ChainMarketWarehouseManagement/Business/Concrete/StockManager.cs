using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class StockManager : IStockService
    {
        private readonly IStockDal _stockDal;
        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        public IResult AddStock(AddStockDto addstockDto)
        {
            var newStock = new Stock();
            newStock.IncomingWarehouseID = addstockDto.IncomingWarehouseID;
            newStock.ProductID = addstockDto.ProductID;
            newStock.Quentity = addstockDto.Quentity;
            _stockDal.Add(newStock);
            return new SuccessResult(Messages.StockAdded);
        }

        public IDataResult<List<Stock>> GetAll()
        {
            return new SuccessDataResult<List<Stock>>(_stockDal.GetAll(), Messages.StocksListed);
        }

        public IDataResult<Stock> GetById(int stockID)
        {
            return new SuccessDataResult<Stock>(_stockDal.Get(p => p.Id == stockID));
        }

        public IResult TransferStock(AddStockDto addstockDto)
        {
            var newStock = new Stock();
            newStock.IncomingWarehouseID = addstockDto.IncomingWarehouseID;
            newStock.OutgoingWarehouseID = addstockDto.OutgoingWarehouseID;
            newStock.ProductID = addstockDto.ProductID;
            newStock.Quentity = addstockDto.Quentity;
            _stockDal.Add(newStock);
            return new SuccessResult(Messages.StockTransferred);
        }
    }
}
