using AutoMapper;
using AutoMapper.Configuration;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace mapper_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.lastname = "lastname test";
            customer.surname = "surname test";
            customer.address = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type";
            customer.email = "test@test.com";
            customer.phone = "44525010101";

            var validator = new CustomerValidator();
            ValidationResult results = validator.Validate(customer);

            bool success = results.IsValid;
            IList<ValidationFailure> failures = results.Errors;

            if (!success)
            {
                foreach (var fail in failures)
                {
                    Console.WriteLine(fail.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Entity Is Validate");
            }
        }
    }
}




