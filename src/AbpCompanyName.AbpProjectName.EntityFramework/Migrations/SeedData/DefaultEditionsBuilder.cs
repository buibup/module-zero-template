﻿using System.Linq;
using Abp.Application.Editions;
using AbpCompanyName.AbpProjectName.Editions;
using AbpCompanyName.AbpProjectName.EntityFramework;

namespace AbpCompanyName.AbpProjectName.Migrations.SeedData
{
    public class DefaultEditionsBuilder
    {
        private readonly AbpProjectNameDbContext _context;

        public DefaultEditionsBuilder(AbpProjectNameDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }   
        }
    }
}