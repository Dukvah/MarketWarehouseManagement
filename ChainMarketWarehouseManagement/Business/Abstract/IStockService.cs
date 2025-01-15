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
    public interface IStockService
    {
        IDataResult<List<Stock>> GetAll();
        IDataResult<Stock> GetById(int stockID);
        IResult AddStock(AddStockDto addstockDto);
        IResult TransferStock(AddStockDto addstockDto);
    }
}
