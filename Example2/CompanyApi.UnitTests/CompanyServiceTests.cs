using CompanyApi.Application.Services;
using CompanyApi.Domain.Interfaces.Repositories;
using CompanyApi.Domain.Mocks;
using CompanyApi.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace CompanyApi.UnitTests
{
    [TestClass]
    public class CompanyServiceTests
    {
        List<Company> expectedCompanies;
        Mock<ICompanyRepository> mockCompanyRepository;
        CompanyService companyService;

        [TestInitialize]
        public void InitializeTestData()
        {
            expectedCompanies = CompanyMock.Companies();
            mockCompanyRepository = new Mock<ICompanyRepository>();
            companyService = new CompanyService(mockCompanyRepository.Object);

            mockCompanyRepository.Setup(m => m.GetAll()).Returns(expectedCompanies);

            mockCompanyRepository.Setup(m => m.AddCompany(It.IsAny<Company>())).Returns(
                (Company target) =>
                {
                    expectedCompanies.Add(target);

                    return target.Id;
                });
            mockCompanyRepository.Setup(m => m.UpdateCompany(It.IsAny<Company>())).Returns(
                (Company target) =>
                {
                    Company companyToUpdate = expectedCompanies.Find(c => c.Id == target.Id);

                    expectedCompanies.Remove(companyToUpdate);
                    expectedCompanies.Add(target);

                    return target;
                });
            mockCompanyRepository.Setup(m => m.GetCompanyById(It.IsAny<int>())).Returns(
                (int companyId) =>
                {
                    Company company = expectedCompanies.Find(c => c.Id == companyId);
                    return company;
                });
        }

        [TestMethod]
        public void GetAll_ExistsCompanies_ReturnCompanyList()
        {
            var actualCompanies = companyService.GetAll();

            Assert.AreSame(expectedCompanies, actualCompanies);
        }

        [TestMethod]
        public void AddCompany_NewCompany_ReturnOk()
        {
            int companiesCount = companyService.GetAll().Count;

            Assert.AreEqual(3, companiesCount);

            Company newCompany = new Company()
            {
                Id = 0,
                Name = "Algeiba BS",
                Cuit = "20-12345678-4",
                Country = "Arg",
                Province = "BA",
                Address = "Parana 771",
                PhoneNumber = "+5401150204010"
            };
            companyService.AddCompany(newCompany);

            companiesCount = companyService.GetAll().Count;
            Assert.AreEqual(4, companiesCount);
        }

        [TestMethod]
        public void UpdateCompany_CompanyExists_ReturnCompanyUpdated()
        {
            var companyOriginal = companyService.GetCompanyById(3);

            Company company = new Company()
            {
                Id = 3,
                Name = "Algeiba Start IT",
                Cuit = "20-12345678-4",
                Country = "Argentina",
                Province = "CABA",
                Address = "Parana 771",
                PhoneNumber = "+5401150204010"
            };
            companyService.UpdateCompany(company);
            var companyUpdated = companyService.GetCompanyById(3);

            Assert.AreEqual(company.Name, companyUpdated.Name);
            Assert.AreEqual(company.Country, companyUpdated.Country);
            Assert.AreEqual(company.Province, companyUpdated.Province);
            Assert.AreNotEqual(companyOriginal.Name, companyUpdated.Name);
            Assert.AreNotEqual(companyOriginal.Country, companyUpdated.Country);
            Assert.AreNotEqual(companyOriginal.Province, companyUpdated.Province);
        }

        [TestMethod]
        public void GetCompanyById_CompanyExists_ReturnCompany()
        {
            Company expectedCompany = new Company()
            {
                Id = 2,
                Name = "Algeiba Dev",
                Cuit = "20-12345678-2",
                Country = "Arg",
                Province = "BA",
                Address = "Parana 771",
                PhoneNumber = "+5401150204010"
            };

            var actualCompany = companyService.GetCompanyById(2);

            Assert.AreEqual(expectedCompany.Name, actualCompany.Name);
            Assert.AreEqual(expectedCompany.Country, actualCompany.Country);
            Assert.AreEqual(expectedCompany.Province, actualCompany.Province);
        }
    }
}
