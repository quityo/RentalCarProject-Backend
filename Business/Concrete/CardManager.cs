using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult Add(Card entity)
        {
            IResult result = BusinessRules.Run(CheckIfCardIsExists(entity.CardNumber));
            if (result != null)
            {
                return result;
            }
            _cardDal.Add(entity);
            return new SuccessResult("Credit Card Added");
        }


        public IResult Delete(Card entity)
        {
            _cardDal.Delete(entity);
            return new SuccessResult("Credit Card Deleted");
        }

        public IResult DeleteById(int cardId)
        {
            var card = _cardDal.Get(x => x.CardId == cardId);
            _cardDal.Delete(card);
            return new SuccessResult("Credit Card Deleted");
        }

        public IDataResult<List<Card>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IDataResult<Card> Get(Card entity)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(x => x.CardId == entity.CardId));
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll());
        }

        public IDataResult<List<Card>> GetAllCardByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll().Where(x => x.CustomerId == customerId).ToList());
        }

        public IDataResult<Card> GetById(int cardId)
        {
            Card p = new Card();
            if (!_cardDal.GetAll().Any(x => x.CardId == cardId))
            {
                return new ErrorDataResult<Card>("Credit Card NotExist");
            }
            p = _cardDal.GetAll().FirstOrDefault(x => x.CardId == cardId);
            return new SuccessDataResult<Card>(p);
        }

        public IResult GetList(List<Card> list)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Card entity)
        {
            _cardDal.Update(entity);
            return new SuccessResult("Credit Card Updated");
        }
        public IResult IsCardExist(Card card)
        {
            var result = _cardDal.Get(c => c.NameOnTheCard == card.NameOnTheCard && c.CardNumber == card.CardNumber && c.CardCvv == card.CardCvv);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfCardIsExists(string cardNumber)
        {
            if (_cardDal.GetAll().Any(x => x.CardNumber == cardNumber))
            {
                return new ErrorResult("Credit Card Already Exist");
            }
            return new SuccessResult();
        }
    }

    }