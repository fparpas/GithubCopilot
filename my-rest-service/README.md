# My REST Service

This is a simple .NET C# REST service application that provides weather forecast data.

## Project Structure

```
my-rest-service
├── src
│   ├── Controllers
│   │   └── WeatherForecastController.cs
│   ├── Models
│   │   └── WeatherForecast.cs
│   ├── Program.cs
│   └── Startup.cs
├── my-rest-service.sln
└── my-rest-service.csproj
```

## Description

- **Controllers**: Contains the `WeatherForecastController` which handles HTTP requests related to weather forecasts.
- **Models**: Contains the `WeatherForecast` class that defines the structure of the weather forecast data.
- **Program.cs**: The entry point of the application that sets up and runs the web application.
- **Startup.cs**: Configures services and the application's request pipeline.

## Getting Started

1. Clone the repository.
2. Navigate to the project directory.
3. Run the application using the command: `dotnet run`.

## API Endpoints

- `GET /weatherforecast`: Returns a list of weather forecast objects.

## Contributing

Feel free to submit issues or pull requests for improvements or bug fixes.