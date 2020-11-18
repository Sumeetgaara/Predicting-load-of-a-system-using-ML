using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace virtualmlnet_hackathon2020_ml_core.Models
{
    public class WithdrawServiceDataRepresentation
    {
        [LoadColumn(0)]
        public DateTime Date { get; set; }

        [LoadColumn(1)]
        public float WithdrawalServiceCount { get; set; }
    }
}
