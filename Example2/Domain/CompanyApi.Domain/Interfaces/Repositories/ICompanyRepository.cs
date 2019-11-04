using CompanyApi.Domain.Models;
using System.Collections.Generic;

namespace CompanyApi.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Company GetCompanyById(int companyId);
        IList<Company> GetAll();

        IList<Company> GetCompaniesByUserId(string userId);

        int AddCompany(Company company);

        Company UpdateCompany(Company company);
    }
}
