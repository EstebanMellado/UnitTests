using CompanyApi.Domain.Interfaces.Repositories;
using CompanyApi.Domain.Interfaces.Services;
using CompanyApi.Domain.Models;
using System.Collections.Generic;

namespace CompanyApi.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public int AddCompany(Company company)
        {
            return _companyRepository.AddCompany(company);
        }

        public IList<Company> GetAll()
        {
            return _companyRepository.GetAll();
        }

        public IList<Company> GetCompaniesByUserId(string userId)
        {
            return _companyRepository.GetCompaniesByUserId(userId);
        }

        public Company GetCompanyById(int companyId)
        {
            return _companyRepository.GetCompanyById(companyId);
        }

        public Company UpdateCompany(Company company)
        {
            return _companyRepository.UpdateCompany(company);
        }
    }
}
