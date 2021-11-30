using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Abstract.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IUserDal _userDal;
        public CustomerManager(IUserDal userDal, ICustomerDal customerDal)
        {
            _customerDal = customerDal;
            _userDal = userDal;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail());
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetailById(int customerId)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail(c => c.CustomerId == customerId), Messages.CustomerListed);
        }
        public IDataResult<CustomerDetailDto> getCustomerByEmail(string email)
        {
            return new SuccessDataResult<CustomerDetailDto>(_customerDal.getCustomerByEmail(p => p.Email == email));
        }

        public IResult UpdateCustomerDto(CustomerForUptadeDto customer, int customerId)
        {
            var c = _customerDal.GetAll().Where(x => x.CustomerId == customerId).FirstOrDefault();
            
            if (customer.CompanyName != null && customer.CompanyName != "" && customer.CompanyName != " ")
            {
                c.CompanyName = customer.CompanyName;
            }
           

            _customerDal.Update(c);
            return new SuccessResult("User Info Updated");
        }
    }
}