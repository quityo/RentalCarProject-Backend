using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        ICustomerService _customerService;
        ICardService _cardService;
        public PaymentManager(
            IPaymentDal paymentDal,
            ICustomerService customerService,
            ICardService cardService
            )
        {
            _paymentDal = paymentDal;
            _cardService = cardService;
            _customerService = customerService;
        }

        public IResult Add(Payment entity)
        {
            IResult result = BusinessRules.Run(
                CheckIsCreditCardExist(entity.CardNumber, entity.ExpirationDate, entity.CardCvv));

            if (result != null)
            {
                return result;
            }
            _paymentDal.Add(entity);

            return new SuccessResult("Payment Add");
        }

        public IResult Delete(Payment entity)
        {
            _paymentDal.Delete(entity);
            return new SuccessResult("Payment Delete");
        }

        public IDataResult<Payment> GetById(int PaymentId)
        {
            Payment p = new Payment();
            if (_paymentDal.GetAll().Any(x => x.PaymentId == PaymentId))
            {
                p = _paymentDal.GetAll().FirstOrDefault(x => x.PaymentId == PaymentId);
            }
            else Console.WriteLine("Payment Not Exist");
            return new SuccessDataResult<Payment>(p);
        }

        public IDataResult<Payment> Get(Payment entity)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(x => x.PaymentId == entity.PaymentId));
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IResult GetList(List<Payment> list)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Payment entity)
        {
            _paymentDal.Update(entity);
            return new SuccessResult("Payment Updated");
        }

        private IResult CheckIsCreditCardExist(string cardNumber, string expirationDate, string cardCvv)
        {
            if (_cardService.GetAll().Data.Any(x => x.CardNumber == cardNumber))
            {
                if (!_cardService.GetAll().Data.Any(
                    x => x.CardNumber == cardNumber &&
                    x.ExpirationDate == expirationDate &&
                    x.CardCvv == cardCvv
                    ))
                {
                    return new ErrorResult("Credit Card Not Exist");
                }
            }
            return new SuccessResult();
        }
    }
}
