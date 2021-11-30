using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService : IEntityService<Card>
    {
        IDataResult<List<Card>> GetByCardNumber(string cardNumber);
        IResult IsCardExist(Card card);
        IDataResult<List<Card>> GetAllCardByCustomerId(int customerId);
        IResult DeleteById(int cardId);
    }
}

