using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using virtualmlnet_hackathon2020_ml_core.Models;

namespace virtualmlnet_hackathon2020_ml_core
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MLContext();
            var data = context.Data.LoadFromTextFile<WithdrawServiceDataRepresentation>(@"C:\Users\Sneha More\source\repos\virtualmlnet-hackathon2020\virtualmlnet-hackathon2020-ml-core\service_data.csv", hasHeader: true, separatorChar: ',');
            var pipeline = context.Forecasting.ForecastBySsa(
                nameof(Forecast.ForecastValue),
                nameof(WithdrawServiceDataRepresentation.WithdrawalServiceCount),
                windowSize: 25,
                seriesLength: 31,
                trainSize: 100,
                horizon: 34);

            var model = pipeline.Fit(data);
            var forecastingEngine = model.CreateTimeSeriesEngine<WithdrawServiceDataRepresentation, Forecast>(context);
            var forecasts = forecastingEngine.Predict();

            foreach (var forecast in forecasts.ForecastValue)
            {
                Console.WriteLine(forecast);
            }

            Console.ReadLine();
        }
    }
}
