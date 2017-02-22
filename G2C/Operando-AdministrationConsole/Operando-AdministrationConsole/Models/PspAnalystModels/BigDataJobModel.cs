﻿using System;
using System.ComponentModel.DataAnnotations;
using eu.operando.common.Entities;
using eu.operando.core.bda.Model;

namespace Operando_AdministrationConsole.Models.PspAnalystModels
{
    public class BigDataJobModel
    {
        public Guid? JobId { get; set; }

        [Required]
        public string JobName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CurrentVersionNumber { get; set; }

        [Required]
        public string DefinitionLocation { get; set; }

        [Required]
        public decimal CostPerExecution { get; set; }

        [Required]
        public Money.CurrencyCode SelectedCurrency { get; set; }

        public string SelectedOsp { get; set; }

        public Money.CurrencyCode[] AvailableCurrencies { get; set; }

        public string[] AvailableOsps { get; set; }

        /// <summary>
        /// Default ctor required for MVC model serialization
        /// </summary>
        // ReSharper disable once EmptyConstructor
        public BigDataJobModel()
        {
            
        }
    }
}