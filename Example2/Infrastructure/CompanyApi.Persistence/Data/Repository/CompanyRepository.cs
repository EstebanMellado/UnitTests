using CompanyApi.Domain.Interfaces.Repositories;
using CompanyApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyApi.Persistence.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyContext _companyContext;
        public CompanyRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }
        public int AddCompany(Company company)
        {
            Company newCompany = new Company()
            {
                Id = 0,
                Name = company.Name,
                Address = company.Address,
                Country = company.Country,
                PhoneNumber = company.PhoneNumber,
                Province = company.Province,
                Cuit = company.Cuit
            };
            _companyContext.Company.Add(newCompany);
            _companyContext.SaveChanges();
            return company.Id;
        }

        public IList<Company> GetAll()
        {
            return _companyContext.Company.ToList();
        }

        public IList<Company> GetCompaniesByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Company GetCompanyById(int companyId)
        {
            throw new NotImplementedException();
        }

        public Company UpdateCompany(Company company)
        {
            _companyContext.Entry(company).State = EntityState.Modified;
            _companyContext.SaveChanges();
            return company;
        }
    }
}
