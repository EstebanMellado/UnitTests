using CompanyApi.Domain.Models;
using System.Collections.Generic;

namespace CompanyApi.Domain.Interfaces.Services
{
    public interface ICompanyService
    {
        Company GetCompanyById(int companyId);
        IList<Company> GetAll();

        IList<Company> GetCompaniesByUserId(string userId);

        int AddCompany(Company company);

        Company UpdateCompany(Company company);
    }
}
