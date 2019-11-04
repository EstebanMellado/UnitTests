using CompanyApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApi.Domain.Mocks
{
    public static class CompanyMock
    {
        public static List<Company> Companies()
        {
            return new List<Company>
            {
                new Company()
                {
                    Id = 1,
                    Name = "Algeiba IT",
                    Cuit = "20-12345678-1",
                    Country = "Arg",
                    Province = "BA",
                    Address = "Parana 771",
                    PhoneNumber = "+5401150204010"
                },
                new Company()
                {
                    Id = 2,
                    Name = "Algeiba Dev",
                    Cuit = "20-12345678-2",
                    Country = "Arg",
                    Province = "BA",
                    Address = "Parana 771",
                    PhoneNumber = "+5401150204010"
                },
                new Company()
                {
                    Id = 3,
                    Name = "Algeiba ST",
                    Cuit = "20-12345678-3",
                    Country = "Arg",
                    Province = "BA",
                    Address = "Parana 771",
                    PhoneNumber = "+5401150204010"
                }
            };
        }
    }
}
